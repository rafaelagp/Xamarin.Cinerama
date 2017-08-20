using Xamarin.Forms;

namespace Cinerama.Controls
{
	public class MultilineLabel : Label
	{
		public int MaxLines
		{
			get { return (int)GetValue(MaxLinesProperty); }
			set { SetValue(MaxLinesProperty, value); }
		}

		public static readonly BindableProperty MaxLinesProperty = BindableProperty.Create(nameof(MaxLines),
		                                                                                   typeof(int),
		                                                                                   typeof(MultilineLabel),
		                                                                                   0);
	}
}
