using System.ComponentModel;
using Cinerama.Controls;
using Cinerama.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MultilineLabel), typeof(MultilineLabelRenderer))]
namespace Cinerama.iOS.Renderers
{
	public class MultilineLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null && e.NewElement != null)
			{
				Control.Lines = ((MultilineLabel)e.NewElement).MaxLines;
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName.Equals(MultilineLabel.MaxLinesProperty))
			{
				Control.Lines = ((MultilineLabel)Element).MaxLines;
			}
		}
	}
}
