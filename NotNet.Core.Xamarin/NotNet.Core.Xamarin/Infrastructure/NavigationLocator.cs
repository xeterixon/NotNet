using System;
using System.Linq;
using System.Reflection;
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
		public Task NavigateTo(string visualElementName,params object[] args)		{
			var page = BuildPage(visualElementName,args);
			if (page != null) 
			{
				return Navigation.PushAsync(page);
			}
			else
			{
				var message = $"Wrong type. {visualElementName} must be either a View or a Page";
				System.Diagnostics.Debug.WriteLine(message);
				throw new ArgumentException(message);
			}
		}
		private Page BuildPage(string name) 
		{
			var entry = _container.GetEntry(name);
			if (typeof(View).GetTypeInfo().IsAssignableFrom(entry.Interface.GetTypeInfo())) {
				return _container.ResolveWrappedView(entry.Interface);
			}
			if (typeof(Page).GetTypeInfo().IsAssignableFrom(entry.Interface.GetTypeInfo())) {
				return (Page)_container.Resolve(entry.Interface);
			}
			return null;
		}
		private Page BuildPage(string name, params object[] args)
		{
			var entry = _container.GetEntry(name);
			if (typeof(View).GetTypeInfo().IsAssignableFrom(entry.Interface.GetTypeInfo())) {
				return _container.ResolveWrappedView(entry.Interface,args);
			}
			if (typeof(Page).GetTypeInfo().IsAssignableFrom(entry.Interface.GetTypeInfo())) {
				return (Page)_container.Resolve(entry.Interface,args);
			}
			return null;
		}


		public Task NavigateTo(string visualElementName) 
		{
			var page = BuildPage(visualElementName);
			if (page != null) {
				return Navigation.PushAsync(page);
			} 
			else 
			{
				var message = $"Wrong type. {visualElementName} must be either a View or a Page";
				System.Diagnostics.Debug.WriteLine(message);
				throw new ArgumentException(message);
			}
		}

		public Task NavigateModalTo(string name) 
		{
			var page = BuildPage(name);
			if (page != null) 
			{
				return Navigation.PushModalAsync(page);
			} 
			else 
			{
				var message = $"Wrong type. {name} must be either a View or a Page";
				System.Diagnostics.Debug.WriteLine(message);
				throw new ArgumentException(message);
			}

		}
		public Task NavigateModalTo(string name, params object[] args) 
		{
			var page = BuildPage(name,args);
			if (page != null) {
				return Navigation.PushModalAsync(page);
			} else {
				var message = $"Wrong type. {name} must be either a View or a Page";
				System.Diagnostics.Debug.WriteLine(message);
				throw new ArgumentException(message);
			}

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
