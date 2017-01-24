using System;
using NotNet.Core;
using Xamarin.Forms;

namespace NNCTest.UI
{
	[AutoRegister(ObjectDescription.Base)]
	public class ModalPage1 : ContentPage
	{
		~ModalPage1()
		{
			System.Diagnostics.Debug.WriteLine("~ModalPage1()");

		}
		public ModalPage1()
		{
			Content = new StackLayout {
				Children = {
					new Button { Text = "Popme" , Command=new Command(async (_) => {await  Navigation.PopModalAsync();})}
				}
			};
		}
	}
}

