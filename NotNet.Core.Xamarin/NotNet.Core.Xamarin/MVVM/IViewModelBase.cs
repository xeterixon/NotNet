namespace NotNet.Core.Xamarin
{
	public interface IViewModelBase 
	{
		string Title { get; set; }
		void OnPageAppearing();
		void OnPageDisappearing();
		bool OnBackButtonPressed();
	}
}
