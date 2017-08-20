using System.ComponentModel;
using Cinerama.Controls;
using Cinerama.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MultilineLabel), typeof(MultilineLabelRenderer))]
namespace Cinerama.Droid.Renderers
{
	public class MultilineLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null && e.NewElement != null)
			{
				Control.SetMaxLines(((MultilineLabel)e.NewElement).MaxLines);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName.Equals(MultilineLabel.MaxLinesProperty))
			{
				Control.SetMaxLines(((MultilineLabel)Element).MaxLines);
			}
		}
	}
}
