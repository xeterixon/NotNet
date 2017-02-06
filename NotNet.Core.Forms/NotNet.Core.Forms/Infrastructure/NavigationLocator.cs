using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotNet.Core.Forms
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

		public Task NavigateTo(string visualElementName,params object[] args)		{
			return Navigation.PushAsync(BuildPage(visualElementName, args));
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
			var message = $"Wrong type. {name} must be either a View or a Page";
			System.Diagnostics.Debug.WriteLine(message);
			throw new ArgumentException(message);
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
			var message = $"Wrong type. {name} must be either a View or a Page";
			System.Diagnostics.Debug.WriteLine(message);
			throw new ArgumentException(message);
		}


		public Task NavigateTo(string visualElementName) 
		{
			return Navigation.PushAsync(BuildPage(visualElementName));
		}

		public Task NavigateModalTo(string name) 
		{
			return Navigation.PushModalAsync(BuildPage(name));

		}
		public Task NavigateModalTo(string name, params object[] args) 
		{
			return Navigation.PushModalAsync(BuildPage(name, args));

		}


		public Task NavigateTo<T>() where T : VisualElement
		{
			
			var page = BuildPage(typeof(T).Name);
			return Navigation.PushAsync(page);
		}

		public Task NavigateModalTo<T>() where T : VisualElement
		{
			var page = BuildPage(typeof(T).Name);
			return Navigation.PushModalAsync(page);
		}

		public Task NavigateTo<T>(params object[] args) where T : VisualElement
		{
			var page = BuildPage(typeof(T).Name,args);
			return Navigation.PushAsync(page);
		}

		public Task NavigateModalTo<T>(params object[] args) where T : VisualElement
		{
			var page = BuildPage(typeof(T).Name,args);
			return Navigation.PushModalAsync(page);
		}
	}
}
