using Cinerama.Models;
using Prism.Navigation;

namespace Cinerama.ViewModels
{
	public class MovieDetailViewModel : BaseViewModel, INavigatingAware
	{
		INavigationService _navigationService;

		public MovieModel Movie { get; set; }

		public MovieDetailViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			var movieKey = nameof(Movie);
			if (parameters.ContainsKey(movieKey))
			{
				Movie = parameters[movieKey] as MovieModel;
			}
		}
	}
}
