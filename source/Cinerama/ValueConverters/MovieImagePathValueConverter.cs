using System;
using System.Globalization;
using Cinerama.Utils;
using Xamarin.Forms;

namespace Cinerama.ValueConverters
{
	/// <summary>
	/// Converts a poster filename into an accessible URL.
	/// </summary>
	public class MovieImagePathValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var filename = value as string;
			var size = parameter != null ? parameter as string : DatabaseApiConstants.SMALL_POSTER_SIZE;

			if (!string.IsNullOrWhiteSpace(filename))
			{
				var url = UrlBuilder.CreateImageUri(filename, size);
				return url;
			}

			return "poster_placeholder.png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
