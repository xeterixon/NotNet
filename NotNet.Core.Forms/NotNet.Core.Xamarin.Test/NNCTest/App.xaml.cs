using System.Reflection;
using NotNet.Core;
using NotNet.Core.Forms;

using Xamarin.Forms;

namespace NNCTest
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			Register();

			var registry =  Container.Default.Resolve<IObjectRegistry>();
			registry.SetInstance(Container.Default.Resolve<TestModel1>());
			MainPage = new NavigationPage(Container.Default.Resolve<NNCTestPage>());
		}
		private void Register() 
		{
			// Auto register stuff...
			Container.Default.AutoRegister(typeof(App).GetTypeInfo().Assembly);

			Container.Default.RegisterSingleton<IApplicationDelegate>(new ApplicationDelegate(this, Container.Default));
			Container.Default.RegisterSingleton<Application>(this);

			Container.Default.Register<NNCTestPage>();
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
