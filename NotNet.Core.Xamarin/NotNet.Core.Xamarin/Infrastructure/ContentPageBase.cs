using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public class ContentPageBase : ContentPage
	{
		public IViewModelBase ViewModel{
			get
			{
				return BindingContext as IViewModelBase;
			}
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
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

