using System;
using System.Collections.Generic;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
	[ViewModel(typeof(ViewModelNoArgs))]
	[AutoRegister(ObjectDescription.Base)]
	public partial class ArgsToPage : ContentPage
	{
		INavigationLocator _navigation;
		string Arg;
		public ArgsToPage(INavigationLocator nav, string arg)
		{
			Arg = arg;
			_navigation = nav;
			InitializeComponent();
		}
		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var vm = BindingContext as ViewModelNoArgs;
			if (vm != null) 
			{
				vm.Text.Value = Arg;
			}
		}
	}
}
