using PropertyChanged;

namespace Cinerama.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class BaseViewModel
	{
		public bool IsBusy { get; set; }
		public bool IsNotBusy { get { return !IsBusy; } }
		public string Title { get; set; } = "Cinerama";
	}
}
