using System;
using System.Globalization;
using Cinerama.Models;
using Xamarin.Forms;

namespace Cinerama.ValueConverters
{
	public class MoviePosterPathValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var filename = value as string;
			var baseUrl = $"{Constants.DatabaseApi.BASE_IMAGE_API_URL}/w185"; //TODO receive image size constant as parameter
			var url = $"{baseUrl}{filename}"; //TODO turn into method

			return url;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Not used
			return value;
		}
	}
}
