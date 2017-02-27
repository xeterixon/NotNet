using System;
using System.Collections.Generic;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
	[AutoRegister(ObjectDescription.Base)]
	public partial class ArgsTestRootPage : ContentPage
	{
		async void ArgsToPage(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("ArgsToPage", "Hello Page");
		}

		async void ArgsToVm(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("ArgsToVm", "Hello ViewModel");
		}
		INavigationLocator _navigation;
		public ArgsTestRootPage(INavigationLocator nav)
		{
			_navigation = nav;
			InitializeComponent();
		}
	}
}
