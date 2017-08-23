﻿using System;
namespace NotNet.Core
{
	public interface IContainerConfigurator
	{
		IContainer Container { get; }
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

	[Obsolete("Use IContainerConfigurator. Name change only")]
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
		IContainerConfiguration RegisterSingleton<T>(T instance) where T : class;
		IContainerConfiguration RegisterSingleton<IT, T>()
			where IT : class
			where T : IT;
		IContainerConfiguration RegisterSingleton<T>() where T : class;
	}


}
