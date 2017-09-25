using System;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests.UI
{
	public interface ITestPage4ViewModel
	{
		string Hello { get; set; }
	}
	public class TestPage4ViewModel : ViewModelBase,ITestPage4ViewModel
	{
		public string Hello { get; set; } = "Hello";
	}
	public class TestPage4 : ContentPage
	{
		public TestPage4()
		{
			Content = new Label { Text = "INIT" };
			Content.SetBinding(Label.TextProperty, "Hello");

		}
	}
}

