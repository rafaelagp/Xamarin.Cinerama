using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Cinerama.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System;
using Cinerama.Helpers;

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

			var apiKeyUrlParam = $"?api_key={Constants.DatabaseApi.API_KEY}";
			var languageUrlParam = "&language=en-US";
			var pageUrlParam = $"&page={page}";
			var url = $"{Constants.DatabaseApi.UpcomingMoviesApiUrl}{apiKeyUrlParam}{languageUrlParam}{pageUrlParam}"; //TODO turn into a method

			try
			{
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
