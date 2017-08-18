using Cinerama.Models;
using Cinerama.Utils;
using Prism.Navigation;
using Xamarin.Forms;

namespace Cinerama.ViewModels
{
	public class MovieDetailViewModel : BaseViewModel, INavigatingAware
	{
		INavigationService _navigationService;

		public MovieModel Movie { get; set; }
		public FormattedString FormattedGenres { get; set; }
		public FormattedString FormattedOverview { get; set; }
		public FormattedString FormattedReleaseDate { get; set; }

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
				FormattedGenres = FormatText("genres", Movie.GenreNames);
				FormattedOverview = FormatText("overview", Movie.Overview);
				FormattedReleaseDate = FormatText("release date", Movie.ReleaseDate.ToString("yyyy/MM/dd"));
			}
		}

		FormattedString FormatText(string title, string text)
		{
			var fontSize = 0;
			switch (Device.RuntimePlatform)
			{
				case Device.Android:
					fontSize = 16;
					break;
				default:
					fontSize = 15;
					break;
			}

			var formatted = new FormattedString();
			formatted.Spans.Add(new Span
			{
				Text = $"{title.ToLower()} ",
				FontSize = fontSize,
				FontAttributes = FontAttributes.Bold,
				ForegroundColor = Color.White
			});
			formatted.Spans.Add(new Span
			{
				Text = text,
				FontSize = fontSize,
				ForegroundColor = ColorConstants.SmallText
			});

			return formatted;
		}
	}
}
