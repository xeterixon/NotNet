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
		INavigationLocator _navigation;
		public TestModel2(INavigationLocator nav) 
		{
			_navigation = nav;
			Name = "Some Random Text";
			PopPageCommand = new Command(async () => { await _navigation.PopAsync();});
		}
	}
}
