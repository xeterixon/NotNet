using System;
using System.Collections.Generic;
using NotNet.Core;
using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NNCTest
{
	[AutoRegister(ObjectDescription.Base)]
	[ViewModel(typeof(TestView1ViewModel))]
	public partial class TestView1 : ContentView
	{
		~TestView1() 
		{
			System.Diagnostics.Debug.WriteLine("~TestView1()");
		}
		public TestView1()
		{
			InitializeComponent();
		}
	}
}
