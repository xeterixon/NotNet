using System;
using System.Collections.Generic;
using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NNCTest
{
	public partial class TestPage1 : ContentPage
	{
		~TestPage1()
		{
			System.Diagnostics.Debug.WriteLine("~TestPage1()");
		}
		
		public TestPage1(ITestPage1ViewModel model)
		{
			InitializeComponent();
			BindingContext = model;

		}
	}
}
