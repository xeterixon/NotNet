using System;
using System.Reflection;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public static class ContainerExtensions
	{
		// Creates a ContentPage with TView as content trying to get the BindingContext from an attribute on the TView
		public static ContentPage ResolvePage<TView>(this Container container)
			where TView:ContentView, new()
		{
			var attr = typeof(TView).GetTypeInfo().GetCustomAttribute<ViewModelAttribute>();
			object vm = null;
			if (attr != null) 
			{
				vm = container.GetService(attr.ViewModelType);	
			}
			return new ContentPage { Content = new TView(), BindingContext = vm };
		}

		// Creates a TView trying to get the BindingContext from an attribute on the TView
		public static TView ResolveView<TView>(this Container container)
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
