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
			Container.Default.AutoRegister(typeof(App).GetTypeInfo().Assembly);
			Container.Default.RegisterSingleton<IApplicationDelegate>(new ApplicationDelegate(this,Container.Default));
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
