using System.Collections.Generic;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public class ApplicationDelegate : IApplicationDelegate
	{
		public Application App { get;private set; }
		public INavigation Navigation => Navigations.Peek();
		private Stack<INavigation> Navigations { get; set; } = new Stack<INavigation>();

		public ApplicationDelegate(Application app, IContainer container)
		{
			App = app;
			app.PropertyChanged += Application_PropertyChanged;
			app.ModalPopped += ModalPopped;
			app.ModalPushing += ModalPushing;
			container.RegisterSingleton<INavigationLocator>(new NavigationLocator(this,container));
		}

		void Application_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if ("MainPage" == e.PropertyName) {
				var navpage = (App.MainPage as NavigationPage);
				if (App.MainPage?.Navigation != null) 
				{
					Navigations.Push(App.MainPage.Navigation);
				}
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

		void ModalPopped(object sender, ModalPoppedEventArgs e)
		{
			var navpage = e.Modal as NavigationPage;
			if (navpage != null) 
			{
				navpage.Popped -= NonModelPagePopped;
			}
			e.Modal?.Cleanup();
			if (Navigations.Count > 1 && e.Modal?.Navigation != null) 
			{
				Navigations.Pop();
			}
		}

		void ModalPushing(object sender, ModalPushingEventArgs e)
		{
			var navpage = e.Modal as NavigationPage;
			if (navpage != null)
			{
				navpage.Popped += NonModelPagePopped;
			}

			if (e.Modal.Navigation != null) 
			{
				Navigations.Push(e.Modal.Navigation);
			}
		}

	}
}
