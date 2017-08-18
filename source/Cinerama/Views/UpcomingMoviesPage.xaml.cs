using Cinerama.Interfaces;
using Xamarin.Forms;

namespace Cinerama.Views
{
	public partial class UpcomingMoviesPage : CustomContentPage
	{
		IDeviceOrientation _deviceOrientation;
		
		public UpcomingMoviesPage(IDeviceOrientation deviceOrientation)
		{
			InitializeComponent();

			_deviceOrientation = deviceOrientation;
			SetLayout(_deviceOrientation.GetOrientation());
		}

		void OnOrientationChange(object sender, PageOrientationEventArgs e)
		{
			SetLayout(e.Orientation);
		}

		void SetLayout(PageOrientation orientation)
		{
			switch (orientation)
			{
				case PageOrientation.Horizontal:
					ListView.RowHeight = 250;
					ListView.ItemTemplate = LandscapeDataTemplate;
					break;
				case PageOrientation.Vertical:
					ListView.RowHeight = 150;
					ListView.ItemTemplate = PortraitDataTemplate;
					break;
			}
		}
	}
}
