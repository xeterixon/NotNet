using System;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public static class ContainerConfigurationExtensions
	{
		public static IContainerConfiguration AddApplicationDelegate(this IContainerConfiguration self, Application app) 
		{
			if (!self.Container.IsRegistered<IApplicationDelegate>())
			{
				self.RegisterSingleton<IApplicationDelegate>(new ApplicationDelegate(self.Container, app));
			}
			return self;
		}
		public static IContainerConfiguration AddNavigationLocator(this IContainerConfiguration self) 
		{

			if (!self.Container.IsRegistered<INavigationLocator>())
			{
				self.Container.RegisterSingleton<INavigationLocator, NavigationLocator>();
			}
			return self;
		}
	}
}
