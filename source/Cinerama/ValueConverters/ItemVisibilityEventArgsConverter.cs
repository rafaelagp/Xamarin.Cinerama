using System;
using System.Globalization;
using Xamarin.Forms;

namespace Cinerama.ValueConverters
{
	/// <summary>
	/// Part of the infinite scroller solution by Rasmus Christensen
	/// https://github.com/rasmuschristensen/SimpleListViewInfiniteScrolling
	/// </summary>
	public class ItemVisibilityEventArgsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var eventArgs = value as ItemVisibilityEventArgs;
			return eventArgs.Item;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
