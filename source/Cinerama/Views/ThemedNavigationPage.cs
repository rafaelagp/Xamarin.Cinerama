using Cinerama.Utils;
using Xamarin.Forms;

namespace Cinerama
{
	public class ThemedNavigationPage : NavigationPage
	{
		public ThemedNavigationPage(Page page) : base(page)
		{
			BarBackgroundColor = ColorConstants.NavigationBarBackground;
			BarTextColor = ColorConstants.Accent;
		}
	}
}
