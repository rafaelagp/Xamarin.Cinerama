using System;
using Cinerama.ViewModels;
using Cinerama.Views;
using Prism.Unity;
using Xamarin.Forms;

namespace Cinerama
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			NavigationService.NavigateAsync(new Uri("/NavigationPage/UpcomingMoviesPage?Title=Cinerama", UriKind.Absolute));
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<UpcomingMoviesPage, UpcomingMoviesViewModel>();
		}
	}
}
