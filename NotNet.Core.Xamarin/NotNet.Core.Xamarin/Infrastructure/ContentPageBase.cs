using System;

using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public class ContentPageBase : ContentPage
	{
		public ContentPageBase() { }
		protected override void OnAppearing()
		{
			base.OnAppearing();
			var vm = BindingContext as IViewModelBase;
			vm?.OnPageAppearing();
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			var vm = BindingContext as IViewModelBase;
			vm?.OnPageDisappearing();
		}
	}
}

