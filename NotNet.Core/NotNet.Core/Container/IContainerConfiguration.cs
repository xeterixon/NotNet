using System;
namespace NotNet.Core
{
	public interface IContainerConfiguration
	{
		IContainer Container { get; }
		IContainerConfiguration AutoRegister<T>();
		IContainerConfiguration RegisterTransient<T>() where T : class;
		IContainerConfiguration RegisterTransient<IT, T>()
			where IT : class
			where T : IT;
		
		IContainerConfiguration RegisterTransient<T>(Action<T> callback) where T : class;
		IContainerConfiguration RegisterTransient<IT, T>(Action<IT> callback)
			where IT : class
			where T : IT;
		[Obsolete("Use RegisterTransient")]
		IContainerConfiguration Register<T>() where T : class;
		[Obsolete("Use RegisterTransient")]
		IContainerConfiguration Register<IT, T>()
			where IT : class
			where T : IT;
		IContainerConfiguration RegisterSingleton<T>(T instance) where T : class;
		IContainerConfiguration RegisterSingleton<IT, T>()
			where IT : class
			where T : IT;
		IContainerConfiguration RegisterSingleton<T>() where T : class;

	}
}
