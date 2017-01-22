using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public class NavigationLocator : INavigationLocator
	{
		ApplicationWrapper _app;
		public NavigationLocator(ApplicationWrapper app)
		{
			_app = app;
		}

		public INavigation Navigation { get { return _app.Navigation; } }
	}
}
