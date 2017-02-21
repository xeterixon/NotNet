using System;
namespace NotNet.Core.Forms
{
	public class HideNavigationBar : IDisposable
	{
		INavigationLocator _navigation;
		bool _oldValue;
		public HideNavigationBar(INavigationLocator navigation)
		{
			_navigation = navigation;
			_oldValue = _navigation.ShowNavigationBar;
			_navigation.ShowNavigationBar = false;
		}

		public void Dispose()
		{
			_navigation.ShowNavigationBar = _oldValue;
		}
	}
}
