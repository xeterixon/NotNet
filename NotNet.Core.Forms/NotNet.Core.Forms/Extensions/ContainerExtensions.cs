using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public static class ContainerExtensions
	{
		public static void RegisterView<TView,TViewModel>(this IContainer self)
			where TView: BindableObject
			where TViewModel : class
		{
			self.RegisterTransient<TView>();
			var view = self.GetEntry(typeof(TView).Name);
			// It the viewmodel registered? If not register it
			var vm = self.GetEntry(typeof(TViewModel).Name);
			if(vm == null)
			{
				//TODO This does not work that well if TViewModel is an interface
				self.RegisterTransient<TViewModel>();
				vm = self.GetEntry(typeof(TViewModel).Name);
			}
			view.Dependant = vm;
		}

		// Creates a ContentPage with TView as content trying to get the BindingContext from an attribute on the TView
		public static ContentPage ResolveWrappedView<TView>(this IContainer container)
			where TView : View
		{
			return ResolveWrappedView(container, typeof(TView));
		}
		public static void RegisterPageForWrappedView<TPage>(this IContainer self)
			where TPage : ContentPage, IContentPage
		
		{
			var entry = self.RegisteredEntries.FirstOrDefault((arg) => arg.Interface == typeof(IContentPage)) as RegistryEntry;
			if (entry != null)
			{
				entry.Implementation = typeof(TPage);
			}
			else{
				self.RegisterTransient<IContentPage,ContentPageBase>();
			}
		}
		public static ContentPage ResolveWrappedView(this IContainer container, string viewName)
		{
			return ResolveWrappedView(container, container.GetEntry(viewName).Interface);
		}

		public static ContentPage ResolveWrappedView(this IContainer container, string viewName, params object[] args)
		{
			return ResolveWrappedView(container, container.GetEntry(viewName).Interface, args);
		}
		public static ContentPage ResolveWrappedView(this IContainer container, Type viewType)
		{
			var viewEntry = container.GetEntry(viewType.Name);
			var view = (View)container.Resolve(viewType);
			TrySetBindingContext(view, container, viewType);
			return WrappAndBindView(container,view);
		}
		private static ContentPage WrappAndBindView(IContainer container, View view)
		{
			var page = (ContentPage)container.Resolve<IContentPage>();
			page.BindingContext = view.BindingContext;
			page.Content = view;
			BindTitle(page);
			return page;

		}
		public static ContentPage ResolveWrappedView<TView>(this IContainer container, params object[] args)
			where TView : View
		{
			var view = container.ResolveView<TView>(args);
			return WrappAndBindView(container,view);
		}

		public static T ResolvePage<T>(this IContainer container, params object[] args)
			where T : Page
		{
			return (T)container.ResolvePage(typeof(T), args);
		}

		public static T ResolvePage<T>(this IContainer container)
			where T : Page
		{
			return (T)container.ResolvePage(typeof(T));
		}
		static void BindTitle(Page p)
		{
			if (p?.BindingContext == null) return;
			p.SetBinding(Page.TitleProperty, "Title");

		}
		public static Page ResolvePage(this IContainer container, Type type)
		{
			var pageEntry = container.GetEntry(type.Name);

			var page = (Page)container.Resolve(type);
			TrySetBindingContext(page, container, type, null);
			BindTitle(page);
			return page;
		}

		public static Page ResolvePage(this IContainer container, Type type, params object[] args)
		{
			//HACK The args might go to the Page constructor or the ViewModel constructor. Try both...	
			var pageEntry = container.GetEntry(type.Name);
			Page page = null;
			object[] argsToVm = null;
			try
			{
				page = (Page)container.Resolve(type, args);
				argsToVm = null;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"ResolvePage - Args to Page - {ex.Message}");
			}
			try
			{
				page = (Page)container.Resolve(type);
				argsToVm = args;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"ResolvePage - Args to BindingContext - {ex.Message}");
			}
			TrySetBindingContext(page, container, type, argsToVm);
			BindTitle(page);
			return page;
		}


		public static TView ResolveView<TView>(this IContainer container, params object[] vmArgs)
			where TView : View
		{
			var bindable = container.Resolve<TView>();
			var attr = GetViewModelAttribute(typeof(TView));
			bindable.BindingContext = attr != null ? container.Resolve(attr.ViewModelType, vmArgs) : null;
			return bindable;
		}

		public static TElement ResolveView<TElement>(this IContainer container)
			where TElement : View
		{
			var bindable = container.Resolve<TElement>();
			TrySetBindingContext(bindable, container, typeof(TElement));
			return bindable;
		}
		public static ContentPage ResolveWrappedView(this IContainer container, Type viewType, params object[] args)
		{
			var view = (View)container.Resolve(viewType);
			TrySetBindingContext(view, container, viewType, args);
			return WrappAndBindView(container,view);
		}

		static ViewModelAttribute GetViewModelAttribute(Type t)
		{
			return t.GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
		}
		static object CreateViewModel(IContainer container, Type t, params object[] args)
		{
			var attr = GetViewModelAttribute(t);
			Type vmType = null;
			if (attr != null){
				vmType = attr.ViewModelType;	
			}
			else
			{
				var entry = container.GetEntry(t.Name);
				vmType = entry?.Dependant?.Interface;
			}
			//Ok, so this can be written in 1 line, but this is easier to read
			if(vmType == null) return null;
			return args == null ? container.Resolve(vmType) : container.Resolve(vmType, args);
		}

		static void TrySetBindingContext(BindableObject bindable, IContainer container, Type viewType, params object[] args)		{
			try
			{
				var vm = CreateViewModel(container, viewType, args);
				if (vm != null)
				{
					bindable.BindingContext = vm;
				}
				return;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"SetBindingContextFromAttributeIfExist - {ex.Message}");
			}
		}
	}
}
