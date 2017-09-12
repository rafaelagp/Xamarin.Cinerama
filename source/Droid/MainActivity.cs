using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Cinerama.Droid.Utils;
using Cinerama.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Cinerama.Droid
{
	[Activity(Label = "Cinerama", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.Window.RequestFeature(WindowFeatures.ActionBar);
			base.SetTheme(Resource.Style.MyTheme);

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			Forms.Init(this, bundle);

			LoadApplication(new App(new PrismInitializer()));
		}
	}

	public class PrismInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IUnityContainer container)
		{
			container.RegisterType<IDeviceOrientation, DeviceOrientation>(new ContainerControlledLifetimeManager());
		}
	}
}
