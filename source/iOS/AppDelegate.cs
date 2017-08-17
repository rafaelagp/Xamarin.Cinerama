using Foundation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using UIKit;

namespace Cinerama.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App(new PrismInitializer()));

			return base.FinishedLaunching(app, options);
		}
	}

	public class PrismInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IUnityContainer container)
		{
		}
	}
}
