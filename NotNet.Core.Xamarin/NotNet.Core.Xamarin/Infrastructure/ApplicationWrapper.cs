using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public class ApplicationWrapper : Application
	{
		protected INavigation RootNavigation {
			set { Navigations.Push(value); }
		}
		public INavigation Navigation => Navigations.Peek();
		private Stack<INavigation> Navigations { get; set; } = new Stack<INavigation>();
		public ApplicationWrapper()
		{
			ModalPushing += PageModalPushing;
			ModalPopped += PageModalPopped;
		}
		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (nameof(MainPage) == propertyName) 
			{
				var navpage = (MainPage as NavigationPage);
				RootNavigation = MainPage?.Navigation;
				//NOTE If navpage is null, other navigation will most likely not work
				if (navpage != null) 
				{
					navpage.Popped += NonModelPagePopped;
				}
			}
		}

		void NonModelPagePopped(object sender, NavigationEventArgs e)
		{
			var p = e.Page;
			e.Page?.Cleanup();
		}

		void PageModalPopped(object sender, ModalPoppedEventArgs e)
		{
			e.Modal?.Cleanup();
			if (Navigations.Count > 1 && e.Modal?.Navigation != null) {
				Navigations.Pop();
			}
		}
		void PageModalPushing(object sender, ModalPushingEventArgs e)
		{
			if (e.Modal.Navigation != null) {
				Navigations.Push(e.Modal.Navigation);
			}
		}
	}
}
