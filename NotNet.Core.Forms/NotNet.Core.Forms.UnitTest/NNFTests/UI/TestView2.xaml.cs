using System;
using System.Collections.Generic;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
	[ViewModel(typeof(TestModel2))]
	[AutoRegister(ObjectDescription.Base)]
	public partial class TestView2 : ContentView
	{
		public TestView2()
		{
			InitializeComponent();
		}
	}
}
