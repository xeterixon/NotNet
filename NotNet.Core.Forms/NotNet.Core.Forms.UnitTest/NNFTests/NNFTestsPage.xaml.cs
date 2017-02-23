﻿using System.Threading.Tasks;
using Xamarin.Forms;
using NotNet.Core;
using NotNet.Core.Forms;
namespace NNFTests
{
	public partial class NNFTestsPage : ContentPage
	{
		async void PushPage1(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("TestPage1");
		}
		async void PushPage2(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("TestView2");
		}
		async void PushPage3(object sender, System.EventArgs e)
		{
			using(new HideNavigationBar(_navigation))
				await _navigation.NavigateTo("TestView2");
		}

		async void PushPage4(object sender, System.EventArgs e)
		{
			await _navigation.NavigateModalTo("ModalPage");
		}
		async void PushPage5(object sender, System.EventArgs e)
		{
			await _navigation.NavigateModalTo("MasterDetail");
		}

		INavigationLocator _navigation;
		public NNFTestsPage()
		{
			InitializeComponent();
			_navigation = Container.Default.Resolve<INavigationLocator>();
		}
	}
}
