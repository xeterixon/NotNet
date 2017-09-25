using System.Threading.Tasks;
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

		async void PushPage6(object sender, System.EventArgs e)
		{
			var page = Container.Default.Resolve<ModalRootPage>();
			await _navigation.PushModalAsync(new NavigationPage(page) { Title = "New nav stack" });
		}
		async void PushPage7(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("ArgsTestRootPage");
		}
		async void PushPage8(object sender, System.EventArgs e)
		{
            await _navigation.NavigateModalTo("TabPageTest");
		}
		async void PushPage9(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("TestPage3");
		}
		async void PushPage10(object sender, System.EventArgs e)
		{
			await _navigation.NavigateTo("TestPage4");
		}

		INavigationLocator _navigation;
		public NNFTestsPage()
		{
			InitializeComponent();
			_navigation = Container.Default.Resolve<INavigationLocator>();
		}
	}
}
