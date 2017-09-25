using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
    [ViewModel(typeof(ViewModelNoArgs))]
	[AutoRegister]
	public partial class ArgsToPage : ContentPage
	{
#pragma warning disable
		readonly INavigationLocator _navigation;
#pragma warning restore
		string Arg;
		public ArgsToPage(INavigationLocator nav, string arg)
		{
			Arg = arg;
			_navigation = nav;
			InitializeComponent();
		}
		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var vm = BindingContext as ViewModelNoArgs;
			if (vm != null) 
			{
				vm.Text.Value = Arg;
			}
		}
	}
}
