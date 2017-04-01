using System;
using System.Collections.Generic;
using NotNet.Core;
using NotNet.Core.Forms;
            
using Xamarin.Forms;

namespace NNFTests
{
	[ViewModel(typeof(ViewModelStringArg))]
	[AutoRegister(ObjectDescription.Base)]

	public partial class ArgsToVm : ContentPage
	{
#pragma warning disable 
		readonly INavigationLocator _navigation;
#pragma warning restore
		public ArgsToVm(INavigationLocator nav)
		{
			_navigation = nav;
			InitializeComponent();
		}
	}
}
