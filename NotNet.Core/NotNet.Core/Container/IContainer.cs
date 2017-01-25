using System;
using System.Reflection;

namespace NotNet.Core
{
	public interface IContainer: IServiceProvider
	{
		/// <summary>
		/// Register an interface and an implementing class.
		/// </summary>
		/// <param name="olc">Object life cycle.</param>
		/// <typeparam name="TIface">The interface type.</typeparam>
		/// <typeparam name="TImpl">The implementaion type.</typeparam>
		void Register<TIface, TImpl>(ObjectLifecycle olc = ObjectLifecycle.Transient)
			where TIface : class
			where TImpl : TIface;
		/// <summary>
		/// Register an class,
		/// </summary>
		/// <param name="olc">Object life cycle.</param>
		/// <typeparam name="TImpl">The 1st type parameter.</typeparam>
		void Register<TImpl>(ObjectLifecycle olc = ObjectLifecycle.Transient)
			where TImpl : class;

		/// <summary>
		/// Register an interface and an implementing class as a singleton.
		/// </summary>
		/// <typeparam name="TIface">The interface type.</typeparam>
		/// <typeparam name="TImpl">The implementaion type.</typeparam>
		void RegisterSingleton<TIface, TImpl>()
			where TIface : class
			where TImpl : TIface;
		
		/// <summary>
		/// Registers a singleton instance.
		/// </summary>
		/// <param name="instance">Instance.</param>
		/// <typeparam name="TImpl">The 1st type parameter.</typeparam>
		void RegisterSingleton<TImpl>(TImpl instance)
			where TImpl : class;

		/// <summary>
		/// Fetch an object of type TIface
		/// Throws if no suitable class or interface is found
		/// <returns>An object implementing TIFace</returns>
		/// </summary>
		/// <typeparam name="TIface">The type.</typeparam>
		TIface Resolve<TIface>()
			where TIface : class;

		/// <summary>
		/// Resolves with arguments.
		/// Note that args are injected as the last arguments to the constructor.
		/// Any Resolved arguments are injected first.
		/// This might lead to some unexpected behavior for types in args that can be resolved
		/// </summary>
		/// <returns>An object of type T</returns>
		/// <param name="args">An array of instances</param>
		/// <typeparam name="T">The type to create</typeparam>
		T Resolve<T>(params object[] args);

		object Resolve(Type t, params object[] args);
		object Resolve(Type t);

		/// <summary>
		/// Fetch an object of type TIface and executes the action
		/// Throws if no suitable class or interface is found
		/// <returns>An object implementing TIFace</returns>
		/// </summary>
		/// <param name="action">Action called after the instance has been created</param>
		/// <typeparam name="TIface">The 1st type parameter.</typeparam>
		TIface Resolve<TIface>(Action<TIface> action)
			where TIface : class;

		/// <summary>
		/// Fetch an object of type TIface
		/// <returns>An object implementing TIFace or null if no implementation is found</returns>
		/// </summary>
		/// <typeparam name="TIface">The type.</typeparam>
		TIFace ResolveOrDefault<TIFace>()
			where TIFace : class;

		T ResolveOrDefault<T>(params object[] args);
		/// <summary>
		/// Auto register classes with the AutoRegister attribute
		/// </summary>
		/// <param name="assembly">The assembly holding the classes</param>
		void AutoRegister(Assembly assembly);

		/// <summary>
		/// Check if a type is registered
		/// </summary>
		/// <returns><c>true</c>, if type registered, <c>false</c> otherwise.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		bool IsRegistered<T>();

	}
}
