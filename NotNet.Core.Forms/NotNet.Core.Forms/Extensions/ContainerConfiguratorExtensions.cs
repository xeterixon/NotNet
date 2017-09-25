using System;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	/// <summary>
	/// Xamarin.Forms specific container configurations
	/// </summary>
	public static class ContainerConfiguratorExtensions
	{
		public static IContainerConfigurator AddApplicationDelegate(this IContainerConfigurator self, Application app)
		{
			if (!self.Container.IsRegistered<IApplicationDelegate>())
			{
				self.RegisterSingleton<IApplicationDelegate>(new ApplicationDelegate(self.Container, app));
			}
			return self;
		}
		public static IContainerConfigurator RegisterView<TView,TViewModel>(this IContainerConfigurator self)
			where TView: BindableObject
			where TViewModel : class
		{
			self.Container.RegisterView<TView,TViewModel>();
			return self;
		}
		public static IContainerConfigurator AddNavigationLocator(this IContainerConfigurator self)
		{

			if (!self.Container.IsRegistered<INavigationLocator>())
			{
				self.Container.RegisterSingleton<INavigationLocator, NavigationLocator>();
			}
			return self;
		}
		public static IContainerConfigurator AddPopupService(this IContainerConfigurator self)
		{
			if (!self.Container.IsRegistered<IPopupService>())
			{
				self.Container.RegisterTransient<IPopupService, PopupService>();
			}
			return self;
		}
		public static IContainerConfigurator AddTimerService(this IContainerConfigurator self)
		{
			if (!self.Container.IsRegistered<ITimer>())
			{
				self.Container.RegisterSingleton<ITimer, Timer>();
			}
			return self;
		}
		public static IContainerConfigurator AddDefaultServices(this IContainerConfigurator self, Application app)
		{
			return self.AddApplicationDelegate(app).AddNavigationLocator().AddPopupService().AddTimerService();
		}

	}
}
