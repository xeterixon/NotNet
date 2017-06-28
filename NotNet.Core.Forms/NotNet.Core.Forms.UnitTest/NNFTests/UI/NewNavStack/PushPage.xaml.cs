using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
    [AutoRegister]
	public partial class PushPage : ContentPage
	{
		INavigationLocator _navigation;
		IPopupService _popup;
		int counter;
		public PushPage(INavigationLocator nav, IPopupService pop, int c)
		{
			_popup = pop;
			counter = c + 1;
			_navigation = nav;
			InitializeComponent();
			Title = "Page " + counter;
			OnPropertyChanged(nameof(Title));
		}
		~PushPage()
		{
			System.Diagnostics.Debug.WriteLine("~" + this.GetType().Name + ". Refs " + counter);
		}
		async void PushNewPage(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("PushPage", counter);
		}
		async void PopToRoot(object sender, System.EventArgs e)
		{
			await _navigation.PopToRootAsync();
		}

		async void ShowSheet(object sender, System.EventArgs e)
		{
			var resp = await _popup.ShowActionSheet("Options", "Cancel", null, "Select1", "Select2", "Select3");
			await _popup.ShowAlert("Choice", $"You picked {resp}", "OK");
		}

	}
}
