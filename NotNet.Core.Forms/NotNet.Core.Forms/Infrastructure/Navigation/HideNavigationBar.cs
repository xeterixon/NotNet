using System;
namespace NotNet.Core.Forms
{
	public class HideNavigationBar : IDisposable
	{
		readonly INavigationLocator _navigation;
		readonly bool _oldValue;
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
