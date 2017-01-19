using NotNet.Core;
using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NNCTest
{
	public partial class NNCTestPage : ContentPage
	{
		async void PushPage(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(Container.Default.Resolve<TestPage1>());
		}

		async void PushView(object sender, System.EventArgs e)
		{
			var page = Container.Default.ResolvePage<TestView1>();
			await Navigation.PushAsync(page);
		}

		public NNCTestPage()
		{
			InitializeComponent();
		}
	}
}
