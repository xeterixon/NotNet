using System;
using System.Reflection;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public static class ContainerExtensions
	{
		// Creates a ContentPage with TView as content trying to get the BindingContext from an attribute on the TView
		public static ContentPage ResolveWrappedView<TView>(this IContainer container)
			where TView:ContentView, new()
		{
			var attr = typeof(TView).GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
			object bindingContext = null;
			var page = new ContentPageBase();
			page.BatchBegin();
			page.Content = new TView();
			if (attr != null) 
			{
				bindingContext = container.GetService(attr.ViewModelType);
				page.BindingContext = bindingContext;
				if (typeof(IViewModelBase).GetTypeInfo().IsAssignableFrom(bindingContext.GetType().GetTypeInfo())) 
				{
					var vm = (IViewModelBase)bindingContext;
					page.SetBinding(Page.TitleProperty, nameof(vm.Title));
				}
			}
			page.BatchCommit();
			return page;
		}

		// Creates a TView trying to get the BindingContext from an attribute on the TView
		public static TView ResolveView<TView>(this IContainer container)
			where TView : ContentView, new()
		{
			var attr = typeof(TView).GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
			object vm = null;
			if (attr != null) {
				vm = container.GetService(attr.ViewModelType);			}
			return new TView{ BindingContext = vm };
		}

	}
}
