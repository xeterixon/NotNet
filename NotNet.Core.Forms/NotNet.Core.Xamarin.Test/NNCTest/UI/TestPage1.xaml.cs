using System;
using System.Collections.Generic;
using NotNet.Core.Forms;

using Xamarin.Forms;

namespace NNCTest
{
	[ViewModel(typeof(ITestPage1ViewModel))] 
	public partial class TestPage1 : ContentPage
	{
		~TestPage1()
		{
			System.Diagnostics.Debug.WriteLine("~TestPage1()");
		}
		public TestPage1()
		{
			InitializeComponent();
//			BindingContext = model;
		}
	}
}
