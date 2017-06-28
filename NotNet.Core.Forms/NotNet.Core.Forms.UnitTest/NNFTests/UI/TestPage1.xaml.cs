﻿using NotNet.Core;
using Xamarin.Forms;

namespace NNFTests
{
    [AutoRegister]
	public partial class TestPage1 : ContentPage
	{
		public TestPage1(ITestModel1 model)
		{
			InitializeComponent();
			BindingContext = model;
			Title = model.Name;
		}
	}
}
