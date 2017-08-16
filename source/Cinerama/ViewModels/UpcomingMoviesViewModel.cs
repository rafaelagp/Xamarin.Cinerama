using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cinerama.Models;
using Prism.Navigation;
using System;
using Cinerama.Utils;
using Cinerama.Interfaces;
using Cinerama.Services;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cinerama.ViewModels
{
	public class UpcomingMoviesViewModel : BaseViewModel
	{
		int _lastLoadedPage = 1;
		bool _shouldLoadMore;
		string _lastLoadedMovieTitle;
		INavigationService _navigationService;
		ITheMovieDatabaseService _tmdbService;

		public List<GenreModel> Genres { get; set; }
		public ObservableCollection<MovieModel> Movies { get; set; }

		public ICommand LoadMoreCommand { get; set; }

		public UpcomingMoviesViewModel(ITheMovieDatabaseService tmdbService, INavigationService navigationService)
		{
			_navigationService = navigationService;
			_tmdbService = tmdbService;
			Genres = new List<GenreModel>();
			Movies = new ObservableCollection<MovieModel>();
			LoadMoreCommand = new Command<MovieModel>(LoadMoreUpcomingMovies);
			Task.Run(async () => await AddUpcomingMoviesAsync(_lastLoadedPage));
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			Title = parameters["Title"] as string;
		}

		async void LoadMoreUpcomingMovies(MovieModel item)
		{
			if (item.Title.Equals(_lastLoadedMovieTitle) && _shouldLoadMore)
			{
				await AddUpcomingMoviesAsync(++_lastLoadedPage);
				return;
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
				using (var service = new TheMovieDatabaseService())
				{
					if (Genres.Count == 0)
					{
						Genres.AddRange(await service.GetMovieGenresAsync());
					}

					var movies = await service.GetUpcomingMoviesAsync(page);
					movies.OrderBy(x => x.ReleaseDate)
					      .ToList()
					      .ForEach(AddUpcomingMovie);
					
					_lastLoadedMovieTitle = Movies.Last().Title; 
					_shouldLoadMore = false;
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
