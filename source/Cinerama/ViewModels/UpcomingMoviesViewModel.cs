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

namespace Cinerama.ViewModels
{
	public class UpcomingMoviesViewModel : BaseViewModel
	{
		INavigationService _navigationService;
		ITheMovieDatabaseService _tmdbService;

		public List<GenreModel> Genres { get; set; }
		public ObservableCollection<MovieModel> Movies { get; set; }

		public UpcomingMoviesViewModel(ITheMovieDatabaseService tmdbService, INavigationService navigationService)
		{
			_navigationService = navigationService;
			_tmdbService = tmdbService;
			Genres = new List<GenreModel>();
			Movies = new ObservableCollection<MovieModel>();
			Task.Run(async () => await AddUpcomingMoviesAsync());
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			Title = parameters["Title"] as string;
		}

		async Task AddUpcomingMoviesAsync(int page = 1)
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
				}
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}

			IsBusy = false;
		}

		void AddUpcomingMovie(MovieModel item)
		{
			item.GetGenreNames(Genres);
			Movies.Add(item);
		}
	}
}
