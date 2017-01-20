using System.Reflection;
using NotNet.Core;
using Xamarin.Forms;

namespace NNCTest
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			Register();
			MainPage = new NavigationPage(new NNCTestPage());
		}
		private void Register() 
		{
			Container.Default.RegisterSingleton<IContainer>(Container.Default);
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
