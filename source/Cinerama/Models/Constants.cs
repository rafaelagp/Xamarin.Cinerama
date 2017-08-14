namespace Cinerama
{
	public static class Constants
	{
		public static class DatabaseApi
		{
			public const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
			public const string BASE_API_URL = "https://api.themoviedb.org/3";
			public const string BASE_IMAGE_API_URL = "http://image.tmdb.org/t/p";

			public static string MoviesApiUrl = $"{BASE_API_URL}/movies";
			public static string UpcomingMoviesApiUrl = $"{MoviesApiUrl}/upcoming";
		}
	}
}
