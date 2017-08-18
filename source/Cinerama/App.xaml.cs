﻿using System;
using Cinerama.Interfaces;
using Cinerama.Services;
using Cinerama.ViewModels;
using Cinerama.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cinerama
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			NavigationService.NavigateAsync(new Uri("/CustomNavigationPage/UpcomingMoviesPage", UriKind.Absolute));
		}

		protected override void RegisterTypes()
		{
			Container.RegisterType<IDatabaseApiService, DatabaseApiService>(
				new ContainerControlledLifetimeManager());

			Container.RegisterTypeForNavigation<CustomContentPage>();
			Container.RegisterTypeForNavigation<CustomNavigationPage>();
			Container.RegisterTypeForNavigation<UpcomingMoviesPage, UpcomingMoviesViewModel>();
			Container.RegisterTypeForNavigation<MovieDetailPage, MovieDetailViewModel>();
		}
	}
}
