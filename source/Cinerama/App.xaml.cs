using System;
using Prism.Unity;

namespace Cinerama
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			NavigationService.NavigateAsync(new Uri("/UpcomingMoviesPage", UriKind.Absolute));
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<UpcomingMoviesPage, UpcomingMoviesViewModel>();
		}
	}
}
