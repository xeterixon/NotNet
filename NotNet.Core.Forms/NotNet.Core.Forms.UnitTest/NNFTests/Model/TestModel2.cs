using System.Threading.Tasks;
using System.Windows.Input;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
	[AutoRegister(ObjectDescription.Base)]
	public class TestModel2 : ViewModelBase
 	{
		public string Name { get; private set; }
		public ICommand PopPageCommand { get; private set; }
		public ICommand ShowAlertCommand { get; private set; }
		public ICommand YesNoCommand { get; private set; }
		public ICommand ShowPopupCommand { get; private set; }
		INavigationLocator _navigation;
		IPopupService _popup;
#pragma warning disable
		ITestModel3 _model3;
#pragma warning restore

		public TestModel2(INavigationLocator nav, IPopupService popup, ITestModel3 model3) 
		{
			_model3 = model3;
			_navigation = nav;
			_popup = popup;
			Name = "Some Random Text";
			PopPageCommand = new Command(async () => { await _navigation.PopAsync();});
			ShowPopupCommand = new Command<string>(async (obj) => { await ShowPopup(obj);});
		}
		async Task ShowPopup(string type) 
		{
			if (type == "ALERT") 
			{
				await _popup.ShowAlert("Title", "Some message", "OK");
			}
			if (type == "QUESTION") 
			{
				var resp = await _popup.ShowAlert("Huh?", "Yes or no?", "Yes", "No");
				var msg = resp ? "Yes, it is..." : "No, why not?";
				await _popup.ShowAlert("Aha", msg, "OK");
				
			}
			if (type == "SHEET") 
			{
				var resp = await _popup.ShowActionSheet("Options","Cancel","Delete","This","That", "The other" );
				await _popup.ShowAlert("Choice", $"You picked {resp}", "OK");
			}
		}
	}
}
