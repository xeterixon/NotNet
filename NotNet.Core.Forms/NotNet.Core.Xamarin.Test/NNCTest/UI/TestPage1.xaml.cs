using System;
using System.Collections.Generic;
using NotNet.Core.Forms;

using Xamarin.Forms;

namespace NNCTest
{
	// Does not work yet
	[ViewModel(typeof(ITestPage1ViewModel))] 
	public partial class TestPage1 : ContentPage
	{
		~TestPage1()
		{
			System.Diagnostics.Debug.WriteLine("~TestPage1()");
		}
		public TestPage1(ITestPage1ViewModel model, TestModel2 m2)
		{
			InitializeComponent();
			BindingContext = model;
		}
	}
}
