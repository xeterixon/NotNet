using System;
using System.Reflection;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public static class ContainerExtensions
	{
		// Creates a ContentPage with TView as content trying to get the BindingContext from an attribute on the TView
		public static ContentPage ResolveWrappedView<TView>(this IContainer container)
			where TView:View
		{
			var view = container.ResolveView<TView>();
			var page = new ContentPageBase
			{
				BindingContext = view.BindingContext,
				Content = view
			};
			page.SetBinding(Page.TitleProperty, "Title");
			return page;
		}
		public static ContentPage ResolveWrappedView<TView>(this IContainer container, params object[] args) 
			where TView:View
		{
			var view = container.ResolveView<TView>(args);
			var page = new ContentPageBase {
				BindingContext = view.BindingContext,
				Content = view
			};
			page.SetBinding(Page.TitleProperty, "Title");
			return page;
		}
		private static ViewModelAttribute GetViewModelAttribute(Type t) 
		{
			return t.GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
		}
		private static object CreateViewModelFromAttribute(IContainer container, Type t, params object[] args) 
		{
			var attr = GetViewModelAttribute(t);
			return attr != null ? container.Resolve(attr.ViewModelType, args) : attr;
		}
		private static object CreateViewModelFromAttribute(IContainer container, Type t) 
		{
			var attr = GetViewModelAttribute(t);
			return attr != null ? container.Resolve(attr.ViewModelType) : attr;
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
			bindable.BindingContext = CreateViewModelFromAttribute(container, typeof(TElement));
			return bindable;
		}
		public static ContentPage ResolveWrappedView(this IContainer container, string viewName) 
		{
			return ResolveWrappedView(container, container.GetEntry(viewName).Interface);
		}
		public static ContentPage ResolveWrappedView(this IContainer container, string viewName, params object[] args)		{
			return ResolveWrappedView(container, container.GetEntry(viewName).Interface,args);
		}

		public static ContentPage ResolveWrappedView(this IContainer container, Type viewType)		{
			var view = (View)container.Resolve(viewType);
			var attr = GetViewModelAttribute(viewType);
			view.BindingContext = CreateViewModelFromAttribute(container,viewType);
			var page = new ContentPageBase 
			{

				BindingContext = view.BindingContext,
				Content = view
			};
			page.SetBinding(Page.TitleProperty, "Title");
			return page;

		}
		public static ContentPage ResolveWrappedView(this IContainer container, Type viewType, params object[] args)
		{
			var view = (View)container.Resolve(viewType);
			var attr = GetViewModelAttribute(viewType);
			view.BindingContext = CreateViewModelFromAttribute(container, viewType,args);
			var page = new ContentPageBase {

				BindingContext = view.BindingContext,
				Content = view
			};
			page.SetBinding(Page.TitleProperty, "Title");
			return page;

		}


	}
}
