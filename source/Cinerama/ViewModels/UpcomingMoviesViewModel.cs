using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cinerama.Models;
using Prism.Navigation;
using System;
using Cinerama.Utils;
using Cinerama.Interfaces;
using Cinerama.Services;
using System.Collections.Generic;
using Prism.Commands;
using System.Linq;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System.Threading;

namespace Cinerama.ViewModels
{
	public class UpcomingMoviesViewModel : BaseViewModel, IDestructible
	{
		int _lastLoadedPage = 1;
		bool _hasLoadedLastPage;
		bool _shouldLoadMore;
		int _loadMoreMovieIndex; // Position of the movie list where LoadMoreCommand should be called
		MovieModel _loadMoreMovie;
		MovieModel _lastLoadedMovie;
		CancellationTokenSource _tokenSource;
		INavigationService _navigationService;
		IDatabaseApiService _tmdbService;

		public bool IsNotConnected { get; set; }
		public List<GenreModel> Genres { get; set; }
		public ObservableCollection<MovieModel> Movies { get; set; }

		public DelegateCommand<MovieModel> ItemTappedCommand { get; set; }
		public DelegateCommand<MovieModel> LoadMoreCommand { get; set; }

		public UpcomingMoviesViewModel(IDatabaseApiService tmdbService, INavigationService navigationService)
		{
			_navigationService = navigationService;
			_tmdbService = tmdbService;
			_tokenSource = new CancellationTokenSource();
			IsNotConnected = !CrossConnectivity.Current.IsConnected;
			Genres = new List<GenreModel>();
			Movies = new ObservableCollection<MovieModel>();
			ItemTappedCommand = new DelegateCommand<MovieModel>(NavigateToMovieDetail);
			LoadMoreCommand = new DelegateCommand<MovieModel>(LoadMoreUpcomingMovies);
			CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
			Task.Run(async () => await AddUpcomingMoviesAsync(_lastLoadedPage));
		}

		public void Destroy()
		{
			CrossConnectivity.Current.ConnectivityChanged -= OnConnectivityChanged;
		}

		async void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			if (e.IsConnected)
			{
				IsNotConnected = false;
				await AddUpcomingMoviesAsync(++_lastLoadedPage);
			}
			else
			{
				IsNotConnected = true;
				_shouldLoadMore |= !_hasLoadedLastPage;
				_loadMoreMovie = _lastLoadedMovie = null;

				if (!_tokenSource.IsCancellationRequested)
				{
					_tokenSource.Cancel();
					_tokenSource.Dispose();
					_tokenSource = new CancellationTokenSource();
				}
			}
		}

		async void NavigateToMovieDetail(MovieModel movie)
		{
			await _navigationService.NavigateAsync(nameof(MovieDetailPage),
												   new NavigationParameters { { "Movie", movie } });
		}

		async void LoadMoreUpcomingMovies(MovieModel item)
		{
			if (!IsNotConnected)
			{
				var movieConditions = _loadMoreMovie == null || item == _loadMoreMovie || item == _lastLoadedMovie;
				if (movieConditions && _shouldLoadMore && !_hasLoadedLastPage)
				{
					_shouldLoadMore = false;
					await AddUpcomingMoviesAsync(++_lastLoadedPage);
					return;
				}
			}

			_shouldLoadMore = true;
		}

		void AddUpcomingMovie(MovieModel item)
		{
			item.GetGenreNames(Genres);
			Movies.Add(item);
		}

		async Task AddUpcomingMoviesAsync(int page)
		{
			IsBusy = true;

			try
			{
				if (!IsNotConnected)
				{
					if (Genres.Count == 0)
					{
						Genres.AddRange(await _tmdbService.GetMovieGenresAsync(_tokenSource.Token));
					}

					// found no way to filter through query
					var movies = await _tmdbService.GetUpcomingMoviesAsync(_tokenSource.Token, page);
					if (!_tokenSource.IsCancellationRequested)
					{
						movies = movies.Where(x => !string.IsNullOrWhiteSpace(x.PosterPath)
						                      && !string.IsNullOrWhiteSpace(x.BackdropPath)).ToList();
						movies.ForEach(AddUpcomingMovie);
						
						if (_loadMoreMovieIndex == 0)
						{
							_loadMoreMovieIndex = Movies.Count / 2;
							_loadMoreMovie = Movies[_loadMoreMovieIndex];
						}
						else
						{
							_loadMoreMovieIndex += movies.Count - 1;
							_loadMoreMovie = Movies[_loadMoreMovieIndex];
						}
						
						_lastLoadedMovie = Movies.Last();
						_hasLoadedLastPage = movies.Count == 0;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}

			IsBusy = false;
		}
	}
}
