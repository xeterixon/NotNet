using System;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNCTest
{
	[AutoRegister(ObjectDescription.Base)]
	public class TestPage2 : ContentPage
	{
		INavigationLocator navigation;
		public TestPage2(INavigationLocator nav)
		{
			navigation = nav;
			Content = new StackLayout
			{
				Children = {
					new Button { Text = "Pop me" , Command=new Command(()=> navigation.PopAsync())}
				}
			};
		}
	}
}

