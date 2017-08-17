using Cinerama.Utils;
using Xamarin.Forms;

namespace Cinerama
{
	public class CustomNavigationPage : NavigationPage
	{
		public CustomNavigationPage(Page page) : base(page)
		{
			BarBackgroundColor = ColorConstants.NavigationBarBackground;
			BarTextColor = Color.White;
		}
	}
}
