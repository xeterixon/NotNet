﻿using System.Reflection;
using Xamarin.Forms;
using NotNet.Core;
using NotNet.Core.Forms;

namespace NNFTests
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			RegisterDependencies();

			MainPage = new NavigationPage(new NNFTestsPage());
		}

		private void RegisterDependencies() 
		{

			ContainerConfiguration
				.Use(Container.Default)
				.AutoRegister<App>()
				// Add standard forms related stuff
				.AddApplicationDelegate(this)
				.AddPopupService()
				.AddNavigationLocator() // Intentionally added twice, just to make sure it doesn't break
				.AddNavigationLocator();
			// One could use AddDefaultServices

			
		}
		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}