using System.Reflection;
using NotNet.Core;
using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NNCTest
{
	public partial class App : ApplicationWrapper
	{
		public App()
		{
			InitializeComponent();
			Register();
			MainPage = new NavigationPage(Container.Default.Resolve<NNCTestPage>());
		}
		private void Register() 
		{
			Container.Default.RegisterSingleton<INavigationLocator>(new NavigationLocator(this));
			Container.Default.Register<NNCTestPage>();
			Container.Default.AutoRegister(typeof(App).GetTypeInfo().Assembly);
			Container.Default.Register<TestView1ViewModel>();
			Container.Default.Register<ITestPage1ViewModel, TestPage1ViewModel>();
			Container.Default.Register<TestPage1>();
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
