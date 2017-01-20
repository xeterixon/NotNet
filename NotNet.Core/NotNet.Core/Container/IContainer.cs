using System;
using System.Reflection;

namespace NotNet.Core
{
	public interface IContainer
	{
		void Register<TIface, TImpl>(ObjectLifecycle olc = ObjectLifecycle.NewInstance)
			where TIface : class
			where TImpl : TIface;
		
		void Register<TImpl>(ObjectLifecycle olc = ObjectLifecycle.NewInstance)
			where TImpl : class;

		void RegisterSingleton<TIface, TImpl>()
			where TIface : class
			where TImpl : TIface;

		void RegisterSingleton<TImpl>(TImpl instance)
			where TImpl : class;

		TIface Resolve<TIface>()
			where TIface : class;

		TIface Resolve<TIface>(Action<TIface> action)
			where TIface : class;

		TIFace ResolveOrDefault<TIFace>()
			where TIFace : class;

		void AutoRegister(Assembly assembly);
	}

}
