using System;
using System.Reflection;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public static class ContainerExtensions
	{
		// Creates a ContentPage with TView as content trying to get the BindingContext from an attribute on the TView
		public static ContentPage ResolveWrappedView<TView>(this IContainer container)
			where TView:ContentView
		{
			var attr = typeof(TView).GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
			var view = container.ResolveView<TView>();
			var page = new ContentPageBase
			{
				BindingContext = view.BindingContext,
				Content = view
			};
			page.SetBinding(Page.TitleProperty, "Title");
			return page;
		}
		private static object GetViewModelFromAttribute(IContainer container, Type t) 
		{
			var attr = t.GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
			if (attr != null) 
			{
				return container.GetService(attr.ViewModelType);
			}
			return null;
		}
		public static TElement ResolveView<TElement>(this IContainer container)
			where TElement : View
		{
			var bindable = (TElement)container.GetService(typeof(TElement));
			bindable.BindingContext = GetViewModelFromAttribute(container, typeof(TElement));
			return bindable;
		}
	}
}
