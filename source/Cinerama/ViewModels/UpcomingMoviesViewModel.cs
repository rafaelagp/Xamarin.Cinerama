using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Cinerama.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System;
using Cinerama.Utils;
using Cinerama.Utils.Json;

namespace Cinerama.ViewModels
{
	public class UpcomingMoviesViewModel : BaseViewModel
	{
		HttpClient _httpClient;
		INavigationService _navigationService;

		public ObservableCollection<MovieModel> Movies { get; set; }

		public UpcomingMoviesViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			_httpClient = new HttpClient();
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
				var url = UrlBuilder.CreateUri(Constants.DatabaseApi.UpcomingMoviesApiUrl, page);
				var stringResult = await _httpClient.GetStringAsync(url);
				var jsonSettings = new JsonSerializerSettings
				{
					ContractResolver = new CustomPropertyNamesContractResolver(),
					DateFormatString = "yyyy-MM-dd"
				};
				var movies = JsonConvert.DeserializeObject<MovieModelList>(stringResult, jsonSettings);
				movies.Results.ForEach(Movies.Add);
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}

			IsBusy = false;
		}
	}
}
