using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public class NavigationLocator : INavigationLocator
	{
		ApplicationDelegate _app;
		public NavigationLocator(ApplicationDelegate app)
		{
			_app = app;
		}

		public INavigation Navigation { get { return _app.Navigation; } }
	}
}
