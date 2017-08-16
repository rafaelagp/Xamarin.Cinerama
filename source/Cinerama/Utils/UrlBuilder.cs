using System;
using Cinerama.Models;

namespace Cinerama.Utils
{
	public static class UrlBuilder
	{
		/// <summary>
		/// The api key parameter.
		/// </summary>
		public static string ApiKeyParam = $"{API_KEY_PARAM_NAME}={Constants.DatabaseApi.API_KEY}";

		#region Query Parameter Keys
		/// <summary>
		/// The query key name for the api key parameter.
		/// </summary>
		public const string API_KEY_PARAM_NAME = "api_key";
		/// <summary>
		/// The query key name for the language parameter.
		/// </summary>
		public const string LANG_PARAM_NAME = "language";
		/// <summary>
		/// The query key name for the page parameter.
		/// </summary>
		public const string PAGE_PARAM_NAME = "page";
		#endregion

		#region Poster Image Size Parameters
		/// <summary>
		/// A small size poster parameter.
		/// </summary>
		public const string SMALL_POSTER_SIZE = "w92";
		/// <summary>
		/// A medium size poster parameter.
		/// </summary>
		public const string MEDIUM_POSTER_SIZE = "w185";
		#endregion

		#region Language Parameters
		/// <summary>
		/// The english language parameter.
		/// </summary>
		public const string ENGLISH_LANG = "en-us";
		#endregion

		/// <summary>
		/// Builds a poster image URI for The Movie Database.
		/// </summary>
		/// <returns>The poster URI.</returns>
		/// <param name="filename">Filename returned in a movie query.</param>
		/// <param name="size">A size from the Configuration endpoint.</param>
		public static Uri CreatePosterUri(string filename, string size = SMALL_POSTER_SIZE)
		{
			// Removes the starting '/'
			filename = filename.Substring(1);

			var url = $"{Constants.DatabaseApi.BASE_IMAGE_API_URL}/{size}/{filename}?{ApiKeyParam}";
			return new Uri(url);
		}
		/// <summary>
		/// Builds a query URI for a collection endpoint at The Movie Database.
		/// </summary>
		/// <returns>The endpoint URI with query parameters.</returns>
		/// <param name="endpoint">The endpoint URL.</param>
		/// <param name="page">A pagination number for the endpoint collection.</param>
		/// <param name="language">The language for the returned data.</param>
		public static Uri CreateUri(string endpoint, int page = 1, string language = ENGLISH_LANG)
		{
			var langParam = !language.Equals(ENGLISH_LANG) ? $"&{LANG_PARAM_NAME}={language}" : string.Empty;
			var pageParam = page != 1 ? $"&{PAGE_PARAM_NAME}={page}" : string.Empty;
			var url = $"{endpoint}?{ApiKeyParam}{langParam}{pageParam}";

			return new Uri(url);
		}
		/// <summary>
		/// Builds a query URI for a collection endpoint at The Movie Database.
		/// </summary>
		/// <returns>The URI.</returns>
		/// <param name="endpoint">The endpoint URL.</param>
		/// <param name="language">The language for the returned data.</param>
		public static Uri CreateUri(string endpoint, string language = ENGLISH_LANG)
		{
			return CreateUri(endpoint, 1, language);
		}
	}
}
