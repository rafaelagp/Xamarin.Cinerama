using System.ComponentModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace Cinerama.ViewModels
{
	public class BaseViewModel : BindableBase, INavigatedAware, INotifyPropertyChanged
	{
		public bool IsBusy { get; set; }
		public string Title { get; set; }

		public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{
		}
	}
}
