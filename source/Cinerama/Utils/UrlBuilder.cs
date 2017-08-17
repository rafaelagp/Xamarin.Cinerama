using System;
using DbConstants = Cinerama.Utils.DatabaseApiConstants;

namespace Cinerama.Utils
{
	public static class UrlBuilder
	{
		/// <summary>
		/// Builds a poster image URI for The Movie Database.
		/// </summary>
		/// <returns>The poster URI.</returns>
		/// <param name="filename">Filename returned in a movie query.</param>
		/// <param name="size">A size from the Configuration endpoint.</param>
		public static Uri CreateImageUri(string filename, string size = DbConstants.SMALL_POSTER_SIZE)
		{
			// Removes the starting '/'
			filename = filename.Substring(1);
			var url = $"{DbConstants.BASE_IMAGE_API_URL}/{size}/{filename}?{DbConstants.ApiKeyParam}";

			return new Uri(url);
		}

		/// <summary>
		/// Builds a query URI for a collection endpoint at The Movie Database.
		/// </summary>
		/// <returns>The endpoint URI with query parameters.</returns>
		/// <param name="endpoint">The endpoint URL.</param>
		/// <param name="page">A pagination number for the endpoint collection.</param>
		/// <param name="language">The language for the returned data.</param>
		public static Uri CreateUri(string endpoint, int page = 1, string language = DbConstants.ENGLISH_LANG)
		{
			var langParam = !language.Equals(DbConstants.ENGLISH_LANG) ? 
			                         $"&{DbConstants.LANG_PARAM_NAME}={language}" : string.Empty;
			var pageParam = page != 1 ? $"&{DbConstants.PAGE_PARAM_NAME}={page}" : string.Empty;
			var url = $"{endpoint}?{DbConstants.ApiKeyParam}{langParam}{pageParam}";

			return new Uri(url);
		}

		/// <summary>
		/// Builds a query URI for a collection endpoint at The Movie Database.
		/// </summary>
		/// <returns>The URI.</returns>
		/// <param name="endpoint">The endpoint URL.</param>
		/// <param name="language">The language for the returned data.</param>
		public static Uri CreateUri(string endpoint, string language = DbConstants.ENGLISH_LANG)
		{
			return CreateUri(endpoint, 1, language);
		}
	}
}
