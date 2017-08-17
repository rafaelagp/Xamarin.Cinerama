using Cinerama.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(NoSelectionViewCellRenderer))]
namespace Cinerama.iOS.Renderers
{
	public class NoSelectionViewCellRenderer : ViewCellRenderer
	{
		public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			var cell = base.GetCell(item, reusableCell, tv);
			cell.SelectionStyle = UIKit.UITableViewCellSelectionStyle.None;

			return cell;
		}
	}
}
