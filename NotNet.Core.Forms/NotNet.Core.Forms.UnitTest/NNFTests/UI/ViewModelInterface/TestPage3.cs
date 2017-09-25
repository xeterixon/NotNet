using System;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests.UI.ViewModelInterface
{
	[AutoRegister]
	[ViewModel(typeof(ITestPage3ViewModel))]
	public class TestPage3 : ContentPage
	{
		public TestPage3()
		{
			Content = new Label { Text = "Text" };
		}
		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			((Label)Content).Text = ((ITestPage3ViewModel)BindingContext).Text;
		}
	}
}

