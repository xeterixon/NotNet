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
            RunMessagesTest();
			MainPage = new NavigationPage(new NNFTestsPage());
		}
        private void RunMessagesTest()
        {
            var tester = new PubSubTest();
            tester.SendToTest();
        }
		private void RegisterDependencies() 
		{

			ContainerConfigurator
				.Configure(Container.Default)
				.AutoRegister<App>()
				// Add standard forms related stuff
				.AddApplicationDelegate(this)
				.AddPopupService()
				.RegisterTransient<ITestModel3,TestModel3>((o)=> 
				{
					o.Init();
				})
				.AddTimerService()
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
