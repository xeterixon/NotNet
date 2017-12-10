using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public class ContentPageBase :  ContentPage, IContentPage
	{
		bool _initialAppear = true;
		public IViewModelBase ViewModel
		{
			get
			{
				return BindingContext as IViewModelBase;
			}
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (_initialAppear)
			{
				_initialAppear = false;
				ViewModel?.OnInitialPageAppearing();
			}
			ViewModel?.OnPageAppearing();
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			ViewModel?.OnPageDisappearing();
		}
		protected override bool OnBackButtonPressed()
		{
			if (ViewModel != null)
			{
				return ViewModel.OnBackButtonPressed();
			}
			return base.OnBackButtonPressed();
		}
	}
}

