using System.Collections.ObjectModel;
using Cinerama.Models;
using Prism.Navigation;

namespace Cinerama.ViewModels
{
	public class UpcomingMoviesViewModel : BaseViewModel
	{
		public ObservableCollection<MovieModel> Movies { get; set; }

		public UpcomingMoviesViewModel()
		{
			Movies = new ObservableCollection<MovieModel>();
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			Title = parameters["Title"] as string;
		}
	}
}
