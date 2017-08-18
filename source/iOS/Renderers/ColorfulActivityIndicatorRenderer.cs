using System.ComponentModel;
using Cinerama.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ActivityIndicator), typeof(ColorfulActivityIndicatorRenderer))]
namespace Cinerama.iOS
{
	public class ColorfulActivityIndicatorRenderer : ActivityIndicatorRenderer
	{
		UIActivityIndicatorView _nativeControl;

		protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
		{
			var element = e.NewElement;
			if (element != null)
			{
				var size = element.HeightRequest * 2;
				_nativeControl = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge)
				{
					Color = element.Color.ToUIColor(),
					Hidden = !element.IsVisible,
				};

				SetNativeControl(_nativeControl);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var element = sender as ActivityIndicator;
			if (e.PropertyName.Equals(ActivityIndicator.ColorProperty.PropertyName))
			{
				_nativeControl.Color = element.Color.ToUIColor();
			}

			if (e.PropertyName.Equals(ActivityIndicator.IsRunningProperty.PropertyName))
			{
				if (element.IsRunning)
				{
					_nativeControl.StartAnimating();
				}
				else
				{
					_nativeControl.StopAnimating();
				}
			}

			if (e.PropertyName.Equals(VisualElement.IsVisibleProperty.PropertyName))
			{
				_nativeControl.Hidden = !element.IsVisible;
			}
		}
	}
}
