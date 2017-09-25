using System;
using System.Reflection;

namespace NotNet.Core
{

	public class ContainerConfigurator : IContainerConfigurator
	{
		public IContainer Container { get; private set; }
		/// <summary>
		/// Configure
		/// </summary>
		/// <returns>The container configurator.</returns>
		/// <param name="c">C.</param>
		public static IContainerConfigurator Configure(IContainer c)
		{
			return new ContainerConfigurator(c);
		}
		ContainerConfigurator(IContainer c)
		{
			Container = c;
		}
		public IContainerConfigurator AutoRegister<T>()
		{
			Container.AutoRegister(typeof(T).GetTypeInfo().Assembly);
			return this;
		}
		public IContainerConfigurator RegisterTransient<T>() where T : class
		{
			Container.RegisterTransient<T>();
			return this;
		}
		public IContainerConfigurator RegisterTransient<IT, T>()
			where IT : class
			where T : IT
		{
			Container.RegisterTransient<IT, T>();
			return this;
		}
		public IContainerConfigurator RegisterTransient<T>(Action<T> callback) where T : class
		{
			Container.RegisterTransient<T>(callback);
			return this;
		}
		public IContainerConfigurator RegisterTransient<IT, T>(Action<IT> callback)
			where IT : class
			where T : IT
		{
			Container.RegisterTransient<IT, T>(callback);
			return this;
		}

		public IContainerConfigurator RegisterSingleton<T>(T instance)
			where T : class
		{
			Container.RegisterSingleton<T>(instance);
			return this;
		}
		public IContainerConfigurator RegisterSingleton<IT, T>()
			where IT : class
			where T : IT
		{
			Container.RegisterSingleton<IT, T>();
			return this;
		}
		public IContainerConfigurator RegisterSingleton<T>() where T : class
		{
			Container.RegisterSingleton<T>();
			return this;
		}

	}
}
