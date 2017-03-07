using System;
using System.Collections.Generic;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
	[AutoRegister(ObjectDescription.Base)]
	public partial class ModalPage : ContentPage
	{
		void TryOpenDrawer(object sender, System.EventArgs e)
		{
			_navigation.MasterVisible = true;
			Device.StartTimer(TimeSpan.FromSeconds(2), () => 
			{
				_navigation.MasterVisible = false;
				return false;
			});
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await _navigation.PopModalAsync();
		}
		INavigationLocator _navigation;
		public ModalPage( INavigationLocator nav, IContainer container)
		{
			_navigation = nav;
			InitializeComponent();
			SubView.Content = container.ResolveView<TestView2>();
		}
	}
}
