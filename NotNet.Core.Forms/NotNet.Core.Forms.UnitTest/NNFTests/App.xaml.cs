using System.Reflection;
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
				.Register<IPopupService, PopupService>()
				.AddApplicationDelegate(this)
				.AddNavigationLocator()
				.AddNavigationLocator()
				;
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
