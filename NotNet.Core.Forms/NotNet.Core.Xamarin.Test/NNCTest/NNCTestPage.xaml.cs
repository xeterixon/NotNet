using NNCTest.UI;
using NotNet.Core;
using NotNet.Core.Forms;

using Xamarin.Forms;

namespace NNCTest
{
	public partial class NNCTestPage : ContentPage
	{
		void PushTabPage(object sender, System.EventArgs e)
		{
			_navigation.NavigateTo("TabPage");
		}

		async void PushModal(object sender, System.EventArgs e)
		{

			await _navigation.NavigateModalTo("ModalPage1");
		}

		async void PushPageNoBar(object sender, System.EventArgs e)
		{
			_navigation.ShowNavigationBar = false;
			await _navigation.NavigateTo("TestPage2");
			_navigation.ShowNavigationBar = true;

		}

		async void PushPage1(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("TestPage1",new TestModel2());
		}
		async void PushPage2(object sender, System.EventArgs e)
		{
			var view1 = container.ResolveView<TestView1>(new TestModel2());
			var view2 = container.ResolveView<TestView1>(new TestModel2());
			var page = new ContentPage { Content = new StackLayout { Children = {view1, view2 } } };
			await Navigation.PushAsync(page);
		}

		async void PushView(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("TestView1",new TestModel2());
		}
		IContainer container;
		INavigationLocator _navigation;
		public NNCTestPage( IContainer cont, INavigationLocator navLocator)
		{
			InitializeComponent();
			container = cont;
			_navigation = navLocator;
		}
	}
}
