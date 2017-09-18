using System;
using System.Reflection;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public static class ContainerExtensions
	{
		// Creates a ContentPage with TView as content trying to get the BindingContext from an attribute on the TView
		public static ContentPage ResolveWrappedView<TView>(this IContainer container)
			where TView : View
		{
			var view = container.ResolveView<TView>();
			var page = new ContentPageBase
			{
				BindingContext = view.BindingContext,
				Content = view
			};
			BindTitle(page);
			return page;
		}

		public static ContentPage ResolveWrappedView(this IContainer container, string viewName)
		{
			return ResolveWrappedView(container, container.GetEntry(viewName).Interface);
		}

		public static ContentPage ResolveWrappedView(this IContainer container, string viewName, params object[] args)
		{
			return ResolveWrappedView(container, container.GetEntry(viewName).Interface, args);
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
			var page = (Page)container.Resolve(type);
			SetBindingContextFromAttributeIfExist(page, container, type, null);
			BindTitle(page);
			return page;
		}

		public static Page ResolvePage(this IContainer container, Type type, params object[] args)
		{
			//HACK The args might go to the Page constructor or the ViewModel constructor. Try both...	
			try
			{
				var page = (Page)container.Resolve(type, args);
				SetBindingContextFromAttributeIfExist(page, container, type, args);
				BindTitle(page);
				return page;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"ResolvePage - Args to Page - {ex.Message}");
			}
			try
			{
				var page = (Page)container.Resolve(type);
				SetBindingContextFromAttributeIfExist(page, container, type, args);
				BindTitle(page);
				return page;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"ResolvePage - Args to BindingContext - {ex.Message}");
			}

			return null;
		}

		public static ContentPage ResolveWrappedView(this IContainer container, Type viewType)
		{
			var view = (View)container.Resolve(viewType);
			SetBindingContextFromAttributeIfExist(view, container, viewType);
			var page = new ContentPageBase
			{
				BindingContext = view.BindingContext,
				Content = view
			};
			BindTitle(page);
			return page;
		}

		public static ContentPage ResolveWrappedView<TView>(this IContainer container, params object[] args)
			where TView : View
		{
			var view = container.ResolveView<TView>(args);
			var page = new ContentPageBase
			{
				BindingContext = view.BindingContext,
				Content = view
			};
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
			SetBindingContextFromAttributeIfExist(bindable, container, typeof(TElement));
			return bindable;
		}
		public static ContentPage ResolveWrappedView(this IContainer container, Type viewType, params object[] args)
		{
			var view = (View)container.Resolve(viewType);
			SetBindingContextFromAttributeIfExist(view, container, viewType, args);
			var page = new ContentPageBase
			{
				BindingContext = view.BindingContext,
				Content = view
			};
			BindTitle(page);
			return page;
		}

		static ViewModelAttribute GetViewModelAttribute(Type t)
		{
			return t.GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
		}
		static object CreateViewModelFromAttribute(IContainer container, Type t, params object[] args)
		{
			var attr = GetViewModelAttribute(t);
			if (attr == null) return null;

			return args == null ? container.Resolve(attr.ViewModelType) : container.Resolve(attr.ViewModelType, args);
		}

		static void SetBindingContextFromAttributeIfExist(BindableObject bindable, IContainer container, Type viewType, params object[] args)		{
			try
			{
				var vm = CreateViewModelFromAttribute(container, viewType, args);
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
