namespace NotNet.Core.Forms
{
	public interface IViewModelBase
	{
		string Title { get; set; }
		void OnPageAppearing();
		void OnInitialPageAppearing();
		void OnPageDisappearing();
		bool OnBackButtonPressed();
	}
}
