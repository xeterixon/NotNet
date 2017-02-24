using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public class ApplicationDelegate : IApplicationDelegate
	{
		public Application App { get;private set; }
		public INavigation Navigation => Navigations.Peek();
		private Stack<INavigation> Navigations { get; set; } = new Stack<INavigation>();
		public Page CurrentPage { 
			get 
			{
				return GetCurrentPage();
			} 
		}
		private Page GetCurrentPage() 
		{
			Page p = null;
			// Get the topmost (i.e Last) in the model stack, if there is one
			if (Navigation.ModalStack.Any())
			{
				p = Navigation.ModalStack.Last();
			}
			else 
			{
				p = Navigation.NavigationStack.LastOrDefault();
			}
			return p ?? App.MainPage;
		}
		[Obsolete("Will be removed soon, use the ContainerConfigurator to set up the ApplicationDelegate")]
		public ApplicationDelegate(Application app, IContainer container) : this(container,app)
		{
			container.RegisterSingleton<INavigationLocator>(new NavigationLocator(container));
		}
		public ApplicationDelegate(IContainer container, Application app)
		{
			App = app;
			app.PropertyChanged += Application_PropertyChanged;
			app.ModalPopped += ModalPopped;
			app.ModalPushing += ModalPushing;
			container.RegisterSingleton<IApplicationDelegate>(this);
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
