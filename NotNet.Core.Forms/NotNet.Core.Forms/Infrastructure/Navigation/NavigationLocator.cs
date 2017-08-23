using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public class NavigationLocator : INavigationLocator
	{
		IContainer _container;

		public NavigationLocator(IContainer container)
		{
			_container = container;
		}

		public bool ShowNavigationBar { get; set; } = true;
		public bool ShowBackButton { get; set; } = true;

		public INavigation Navigation
		{
			get
			{
				return _container.ResolveOrDefault<IApplicationDelegate>()?.Navigation;
			}
		}
		public bool MasterVisible
		{
			set
			{
				var page = _container.ResolveOrDefault<IApplicationDelegate>()?.CurrentPage as MasterDetailPage;
				if (page == null) return;
				page.IsPresented = value;
			}
			get
			{
				var page = _container.ResolveOrDefault<IApplicationDelegate>()?.CurrentPage as MasterDetailPage;
				if (page == null) return false;
				return page.IsPresented;

			}
		}

		Page BuildPage(string name)
		{
			return BuildPage(name, null);
		}
		Page BuildPage(string name, params object[] args)
		{
			var entry = _container.GetEntry(name);
			if (entry == null)
			{
				throw new ArgumentException($"No view namned {name} was found");
			}
			if (typeof(View).GetTypeInfo().IsAssignableFrom(entry.Interface.GetTypeInfo()))
			{
				var page =
					args == null ?
					_container.ResolveWrappedView(entry.Interface) :
					_container.ResolveWrappedView(entry.Interface, args);
				NavigationPage.SetHasNavigationBar(page, ShowNavigationBar);
				NavigationPage.SetHasBackButton(page, ShowBackButton);
				return page;
			}
			if (typeof(Page).GetTypeInfo().IsAssignableFrom(entry.Interface.GetTypeInfo()))
			{
				var page =
					args == null ?
					_container.ResolvePage(entry.Interface) :
					_container.ResolvePage(entry.Interface, args);
				NavigationPage.SetHasNavigationBar(page, ShowNavigationBar);
				NavigationPage.SetHasBackButton(page, ShowBackButton);
				return page;
			}
			throw new ArgumentException($"Wrong type. {name} must be either a View or a Page");
		}


		public Task NavigateTo(string visualElementName)
		{
			return NavigateTo(visualElementName, null);
		}
		public Task NavigateTo(string visualElementName, params object[] args)
		{
			return Navigation.PushAsync(BuildPage(visualElementName, args));
		}

		public Task NavigateModalTo(string visualElementName)
		{
			return NavigateModalTo(visualElementName, null);

		}
		public Task NavigateModalTo(string name, params object[] args)
		{
			return Navigation.PushModalAsync(BuildPage(name, args));
		}

		public Task NavigateTo<T>() where T : VisualElement
		{
			return NavigateTo<T>(null);
		}


		public Task NavigateTo<T>(params object[] args) where T : VisualElement
		{
			var page = BuildPage(typeof(T).Name, args);
			return Navigation.PushAsync(page);
		}

		public Task NavigateModalTo<T>() where T : VisualElement
		{
			return NavigateModalTo<T>(null);
		}
		public Task NavigateModalTo<T>(params object[] args) where T : VisualElement
		{
			var page = BuildPage(typeof(T).Name, args);
			return Navigation.PushModalAsync(page);
		}
		public Task ActivateTab(string tabTitle)
		{
			var page = _container.ResolveOrDefault<IApplicationDelegate>()?.CurrentPage as TabbedPage;
			if (page == null) return Task.FromResult(0);
			var tab = page.Children.FirstOrDefault(p => p.Title == tabTitle);
			if (tab == null) return Task.FromResult(0);
			page.CurrentPage = tab;
			return Task.FromResult(0);
		}

	}
}
