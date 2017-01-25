using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public class NavigationLocator : INavigationLocator
	{
		ApplicationDelegate _app;
		IContainer _container;
		public NavigationLocator(ApplicationDelegate app, IContainer container)
		{
			_app = app;
			_container = container;
		}

		public INavigation Navigation { get { return _app.Navigation; } }


		public Task NavigateToView<T>() where T : View
		{
			var page = _container.ResolveWrappedView<T>();
			return Navigation.PushAsync(page);
		}
		public Task NavigateModalToView<T>() where T : View 
		{
			var page = _container.ResolveWrappedView<T>();
			return Navigation.PushModalAsync(page);
		}
		public Task NavigateToView<T>(params object[] args) where T : View
		{
			var page = _container.ResolveWrappedView<T>(args);
			return Navigation.PushAsync(page);
		}
		public Task NavigateModalToView<T>(params object[] args) where T : View
		{
			var page = _container.ResolveWrappedView<T>(args);
			return Navigation.PushModalAsync(page);
		}

		public Task NavigateTo<T>() where T : Page
		{
			var page = _container.Resolve<T>();
			return Navigation.PushAsync(page);
		}

		public Task NavigateModalTo<T>() where T : Page
		{
			var page = _container.Resolve<T>();
			return Navigation.PushModalAsync(page);
			
		}

		public Task NavigateTo<T>(params object[] args) where T : Page
		{
			var page = _container.Resolve<T>(args);
			return Navigation.PushAsync(page);
		}

		public Task NavigateModalTo<T>(params object[] args) where T : Page
		{
			var page = _container.Resolve<T>(args);
			return Navigation.PushModalAsync(page);
		}
	}
}
