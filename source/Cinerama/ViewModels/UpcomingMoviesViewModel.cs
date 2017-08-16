using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cinerama.Models;
using Prism.Navigation;
using System;
using Cinerama.Utils;
using Cinerama.Interfaces;
using Cinerama.Services;

namespace Cinerama.ViewModels
{
	public class UpcomingMoviesViewModel : BaseViewModel
	{
		INavigationService _navigationService;
		ITheMovieDatabaseService _tmdbService;

		public ObservableCollection<MovieModel> Movies { get; set; }

		public UpcomingMoviesViewModel(ITheMovieDatabaseService tmdbService, INavigationService navigationService)
		{
			_navigationService = navigationService;
			_tmdbService = tmdbService;
			Movies = new ObservableCollection<MovieModel>();
			Task.Run(async () => await AddUpcomingMovies());
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			Title = parameters["Title"] as string;
		}

		public async Task AddUpcomingMovies(int page = 1)
		{
			IsBusy = true;

			try
			{
				using (var service = new TheMovieDatabaseService())
				{
					var movies = await service.GetUpcomingMoviesAsync(page);
					movies.ForEach(Movies.Add);
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
