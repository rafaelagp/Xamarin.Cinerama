using System;
using Xamarin.Forms;

namespace Cinerama.Views
{
	public class PageOrientationEventArgs : EventArgs
	{
		public PageOrientationEventArgs(PageOrientation orientation)
		{
			Orientation = orientation;
		}

		public PageOrientation Orientation { get; }
	}

	public enum PageOrientation
	{
		Horizontal = 0,
		Vertical = 1,
	}

	/// <summary>
	/// Custom content page with event to listen for device orientation changes.
	/// By Norman Mackay https://forums.xamarin.com/discussion/88646/detecting-page-orientation-change-for-contentpages
	/// </summary>
	public class OrientationContentPage : ContentPage
	{
		double _width;
		double _height;

		public event EventHandler<PageOrientationEventArgs> OnOrientationChanged = (e, a) => { };

		public OrientationContentPage()
		{
			Init();
		}

		void Init()
		{
			_width = Width;
			_height = Height;
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			var oldWidth = _width;
			const double sizenotallocated = -1;

			base.OnSizeAllocated(width, height);
			if (Equals(_width, width) && Equals(_height, height))
			{
				return;
			}

			_width = width;
			_height = height;

			// ignore if the previous height was size unallocated
			if (Equals(oldWidth, sizenotallocated))
			{
				return;
			}

			// Has the device been rotated ?
			if (!Equals(width, oldWidth))
			{
				OnOrientationChanged.Invoke(this, 
				                            new PageOrientationEventArgs((width < height) ? 
				                                                         PageOrientation.Vertical : 
				                                                         PageOrientation.Horizontal));
			}
		}
	}

}
