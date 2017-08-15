using System;
using System.Globalization;
using Cinerama.Utils;
using Xamarin.Forms;

namespace Cinerama.ValueConverters
{
	public class MoviePosterPathValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var filename = value as string;
			var url = UrlBuilder.CreatePosterUri(filename);

			return url;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Not used
			return value;
		}
	}
}
