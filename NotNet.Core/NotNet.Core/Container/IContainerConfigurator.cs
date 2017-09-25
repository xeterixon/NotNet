using System;
namespace NotNet.Core
{
	public interface IContainerConfigurator
	{
		IContainer Container { get; }
		/// <summary>
		/// Auto register classes with the AutoRegister attribute
		/// </summary>
		/// <returns>A container configurator instance</returns>
		/// <typeparam name="T">A type from the assembly to load items from</typeparam>
		IContainerConfigurator AutoRegister<T>();
		IContainerConfigurator RegisterTransient<T>() where T : class;
		IContainerConfigurator RegisterTransient<IT, T>()
			where IT : class
			where T : IT;

		IContainerConfigurator RegisterTransient<T>(Action<T> callback) where T : class;
		IContainerConfigurator RegisterTransient<IT, T>(Action<IT> callback)
			where IT : class
			where T : IT;
		IContainerConfigurator RegisterSingleton<T>(T instance) where T : class;
		IContainerConfigurator RegisterSingleton<IT, T>()
			where IT : class
			where T : IT;
		IContainerConfigurator RegisterSingleton<T>() where T : class;

	}

}
