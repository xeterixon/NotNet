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
