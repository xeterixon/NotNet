using NNCTest.UI;
using NotNet.Core;
using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NNCTest
{
	public partial class NNCTestPage : ContentPage
	{
		async void PushModal(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(container.Resolve<ModalPage1>());
		}

		async void PushPage1(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(container.Resolve<TestPage1>());
		}
		async void PushPage2(object sender, System.EventArgs e)
		{
			var view1 = container.ResolveView<TestView1>();
			var view2 = container.ResolveView<TestView1>();
			var page = new ContentPage { Content = new StackLayout { Children = {view1, view2 } } };
			await Navigation.PushAsync(page);
		}

		async void PushView(object sender, System.EventArgs e)
		{
			var page = container.ResolveWrappedView<TestView1>();
			await Navigation.PushAsync(page);
		}
		IContainer container;
		public NNCTestPage( IContainer cont)
		{
			InitializeComponent();
			container = cont;
		}
	}
}
