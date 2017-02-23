using System;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public static class ContainerConfigurationExtensions
	{
		public static IContainerConfiguration AddApplicationDelegate(this IContainerConfiguration self, Application app) 
		{
			self.RegisterSingleton<IApplicationDelegate>(new ApplicationDelegate(app, self.Container));
			return self;
		}
	}
}
