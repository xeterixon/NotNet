using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
    [AutoRegister]
	public partial class ModalRootPage : ContentPage
	{
		INavigationLocator _navigaton;
		~ModalRootPage()
		{
			System.Diagnostics.Debug.WriteLine("~" + this.GetType().Name);
		}

		public ModalRootPage(INavigationLocator nav)
		{
			Title = "New nav stack";				
			_navigaton = nav;
			InitializeComponent();

		}

		async void PopMe(object sender, System.EventArgs e)
		{
			await _navigaton.PopModalAsync();
		}

		async void PushNewPage(object sender, System.EventArgs e)
		{
			await _navigaton.NavigateTo("PushPage",0);
		}
	}
}
