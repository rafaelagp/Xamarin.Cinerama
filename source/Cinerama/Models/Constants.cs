namespace Cinerama.Models
{
	public static class Constants
	{
		public static class DatabaseApi
		{
			/// <summary>
			/// The Movie Database API Key.
			/// </summary>
			public const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
			/// <summary>
			/// The base API URL. 
			/// </summary>
			public const string BASE_API_URL = "https://api.themoviedb.org/3";
			/// <summary>
			/// The base image API URL.
			/// </summary>
			public const string BASE_IMAGE_API_URL = "http://image.tmdb.org/t/p";

			/// <summary>
			/// The api key parameter.
			/// </summary>
			public static string ApiKeyParam = $"{API_KEY_PARAM_NAME}={API_KEY}";
			/// <summary>
			/// The movies endpoint API URL.
			/// </summary>
			public static string MoviesApiUrl = $"{BASE_API_URL}/movie";
			/// <summary>
			/// The movie genres endpoint API URL.
			/// </summary>
			public static string MovieGenresApiUrl = $"{BASE_API_URL}/genre/movie/list";
			/// <summary>
			/// The upcoming movies endpoint API URL.
			/// </summary>
			public static string UpcomingMoviesApiUrl = $"{MoviesApiUrl}/upcoming";

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
			public const string SMALL_POSTER_SIZE = "w185";
			/// <summary>
			/// A medium size poster parameter.
			/// </summary>
			public const string MEDIUM_POSTER_SIZE = "w342";
			#endregion

			#region Language Parameters
			/// <summary>
			/// The english language parameter.
			/// </summary>
			public const string ENGLISH_LANG = "en-us";
			#endregion
		}
	}
}
