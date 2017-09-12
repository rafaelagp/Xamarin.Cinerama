using Cinerama.Interfaces;
using Cinerama.Views;
using UIKit;

namespace Cinerama.iOS.Utils
{
	public class DeviceOrientation : IDeviceOrientation
	{
		public PageOrientation GetOrientation()
		{
			var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
			bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
				|| currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

			return isPortrait ? PageOrientation.Vertical : PageOrientation.Horizontal;
		}
	}

}
