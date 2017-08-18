using Android.Content;
using Android.Runtime;
using Android.Views;
using Cinerama.Interfaces;
using Cinerama.Views;

namespace Cinerama.Droid.Utils
{
	public class DeviceOrientation : IDeviceOrientation
	{
		/// <summary>
		/// Gets the device's current orientation.
		/// </summary>
		/// <returns>The orientation.</returns>
		public PageOrientation GetOrientation()
		{
			IWindowManager windowManager = Android.App.Application.Context
			                                      .GetSystemService(Context.WindowService)
			                                      .JavaCast<IWindowManager>();

			var rotation = windowManager.DefaultDisplay.Rotation;
			bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
			return isLandscape ? PageOrientation.Horizontal : PageOrientation.Vertical;
		}
	}
}
