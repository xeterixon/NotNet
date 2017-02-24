using System;
using System.Reflection;

namespace NotNet.Core
{
	public class ContainerConfiguration : IContainerConfiguration
	{
		public IContainer Container { get; private set; }
		public static IContainerConfiguration Use(IContainer c) 
		{
			return new ContainerConfiguration(c);
		}
		private ContainerConfiguration(IContainer c)
		{
			Container = c;
		}
		public IContainerConfiguration AutoRegister<T>()
		{
			Container.AutoRegister(typeof(T).GetTypeInfo().Assembly);
			return this;
		}
		public IContainerConfiguration Register<T>() 
			where T: class
		{
			Container.Register<T>();
			return this;
		}

		public IContainerConfiguration Register<IT, T>() 
			where IT:class
			where T : IT
		{
			Container.Register<IT, T>();
			return this;
		}

		public IContainerConfiguration RegisterSingleton<T>(T instance)
			where T : class
		{
			Container.RegisterSingleton<T>(instance);
			return this;
		}
	}
}
