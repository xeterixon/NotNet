using System;
using System.Collections.Generic;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests
{
	[AutoRegister]
    public partial class ModalPage : ContentPage, ISubscribe
	{
        void ChangeLabel(string str)
        {
            TestLabel.Text = str;
        }

        public Label TestLabel { get; set; }
		void TryOpenDrawer(object sender, System.EventArgs e)
		{
			_navigation.MasterVisible = true;
			Device.StartTimer(TimeSpan.FromSeconds(1), () => 
			{
				_navigation.MasterVisible = false;
				return false;
			});
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await _navigation.PopModalAsync();
		}
		INavigationLocator _navigation;
		public ModalPage( INavigationLocator nav, IContainer container)
		{
			InitializeComponent();
			_navigation = nav;
            TestLabel = CBLabel;
			SubView.Content = container.ResolveView<TestView2>();
            this.Subscribe<string>("change",ChangeLabel);
		}
	}
}
