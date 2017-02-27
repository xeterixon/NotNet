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
		INavigationLocator _navigation;
		public ArgsToVm(INavigationLocator nav)
		{
			_navigation = nav;
			InitializeComponent();
		}
	}
}
