using Cinerama.Interfaces;
using Cinerama.Views;

namespace Cinerama
{
	public partial class MovieDetailPage : OrientationContentPage
	{
		IDeviceOrientation _deviceOrientation;

		public MovieDetailPage(IDeviceOrientation deviceOrientation)
		{
			InitializeComponent();

			_deviceOrientation = deviceOrientation;
			SetLayout(deviceOrientation.GetOrientation());
		}

		void OrientationChanged(object sender, PageOrientationEventArgs e)
		{
			SetLayout(e.Orientation);
		}

		void SetLayout(PageOrientation orientation)
		{
			switch (orientation)
			{
				case PageOrientation.Horizontal:
					Content = LandscapeLayout;
					break;
				default:
					Content = PortraitLayout;
					break;
			}
		}
	}
}
