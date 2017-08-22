using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cinerama.Interfaces;
using Cinerama.Models;
using Cinerama.Utils;
using Cinerama.Utils.Json;
using Newtonsoft.Json;

namespace Cinerama.Services
{
	/// <summary>
	/// The Movie Database API service.
	/// </summary>
	public class DatabaseApiService : IDisposable, IDatabaseApiService
	{
		HttpClient _httpClient;
		JsonSerializerSettings _jsonSettings;

		public DatabaseApiService()
		{
			_httpClient = new HttpClient();
			_jsonSettings = new JsonSerializerSettings
			{
				ContractResolver = new CustomPropertyNamesContractResolver(),
				DateFormatString = "yyyy-MM-dd"
			};
		}
		/// <summary>
		/// Lists upcoming movies asynchronously.
		/// </summary>
		/// <returns>A list of upcoming movies.</returns>
		/// <param name="page">The pagination number.</param>
		/// <param name="language">The movie data language.</param>
		public async Task<List<MovieModel>> GetUpcomingMoviesAsync(CancellationToken token, int page = 1, string language = "en-us")
		{
			var url = UrlBuilder.CreateUri(DatabaseApiConstants.UpcomingMoviesApiUrl, page, language);
			var result = await _httpClient.GetAsync(url, token);
			var content = await result.Content.ReadAsStringAsync();
			var movies = JsonConvert.DeserializeObject<MovieModelList>(content, _jsonSettings);

			return movies.Results;
		}
		/// <summary>
		/// Lists movie genres asynchronously.
		/// </summary>
		/// <returns>A list of movie genres.</returns>
		/// <param name="language">The genre name language.</param>
		public async Task<List<GenreModel>> GetMovieGenresAsync(CancellationToken token, string language = "en-us")
		{
			var url = UrlBuilder.CreateUri(DatabaseApiConstants.MovieGenresApiUrl, language);
			var result = await _httpClient.GetAsync(url, token);
			var content = await result.Content.ReadAsStringAsync();
			var genres = JsonConvert.DeserializeObject<GenreModelList>(content, _jsonSettings);

			return genres.Genres;
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
