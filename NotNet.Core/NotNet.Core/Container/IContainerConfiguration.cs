using System;
namespace NotNet.Core
{
	public interface IContainerConfiguration
	{
		IContainer Container { get; }
		IContainerConfiguration AutoRegister<T>();
		IContainerConfiguration Register<T>() where T : class;
		IContainerConfiguration Register<IT, T>()
			where IT : class
			where T : IT;
		IContainerConfiguration RegisterSingleton<T>(T instance) where T : class;
	}
}
