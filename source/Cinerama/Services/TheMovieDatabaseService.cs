using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cinerama.Interfaces;
using Cinerama.Models;
using Cinerama.Utils;
using Cinerama.Utils.Json;
using Newtonsoft.Json;

namespace Cinerama.Services
{
	public class TheMovieDatabaseService : IDisposable, ITheMovieDatabaseService
	{
		HttpClient _httpClient;
		JsonSerializerSettings _jsonSettings;

		public TheMovieDatabaseService()
		{
			_httpClient = new HttpClient();
			_jsonSettings = new JsonSerializerSettings
			{
				ContractResolver = new CustomPropertyNamesContractResolver(),
				DateFormatString = "yyyy-MM-dd"
			};
		}

		public async Task<List<MovieModel>> GetUpcomingMoviesAsync(int page, string language = "en-us")
		{
			var url = UrlBuilder.CreateUri(Constants.DatabaseApi.UpcomingMoviesApiUrl, page, language);
			var result = await _httpClient.GetStringAsync(url);
			var movies = JsonConvert.DeserializeObject<MovieModelList>(result, _jsonSettings);

			return movies.Results;
		}

		public void Dispose()
		{
			if (_httpClient != null)
			{
				_httpClient.Dispose();
			}
		}
	}
}
