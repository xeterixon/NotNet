using System;
namespace NotNet.Core.Forms
{
	public class HideBackButton : IDisposable
	{
		INavigationLocator _navigation;
		bool _oldValue;
		public HideBackButton(INavigationLocator navigation)
		{
			_navigation = navigation;
			_oldValue = _navigation.ShowBackButton;
			_navigation.ShowBackButton = false;
		}

		public void Dispose()
		{
			_navigation.ShowBackButton = _oldValue;
		}
	}
}
