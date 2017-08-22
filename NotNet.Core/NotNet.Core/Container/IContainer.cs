using System;
using System.Collections.Generic;
using System.Reflection;

namespace NotNet.Core
{
	public interface IContainer
	{


		/// <summary>
		/// Register an interface and an implementing class.
		/// </summary>
		/// <typeparam name="TIface">The interface type.</typeparam>
		/// <typeparam name="TImpl">The implementaion type.</typeparam>
		void RegisterTransient<TIface, TImpl>()
			where TIface : class
			where TImpl : TIface;

		void RegisterTransient<TIface, TImpl>(Action<TIface> callback)
			where TIface : class
			where TImpl : TIface;

		/// <summary>
		/// Register an class,
		/// </summary>
		/// <typeparam name="T">The implementation type.</typeparam>
		void RegisterTransient<T>()
			where T : class;

		void RegisterTransient<T>(Action<T> callback)
			where T : class;

		/// <summary>
		/// Register an interface and an implementing class as a singleton.
		/// </summary>
		/// <typeparam name="TIface">The interface type.</typeparam>
		/// <typeparam name="TImpl">The implementaion type.</typeparam>
		void RegisterSingleton<TIface, TImpl>()
			where TIface : class
			where TImpl : TIface;

		void RegisterSingleton<T>()
			where T : class;

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
		/// <typeparam name="T">The type.</typeparam>
		T Resolve<T>()
			where T : class;

		/// <summary>
		/// Resolves with arguments.
		/// Note that args are injected as the last arguments to the constructor.
		/// Any Resolved arguments are injected first.
		/// This might lead to some unexpected behavior for types in args that can be resolved
		/// </summary>
		/// <returns>An object of type T</returns>
		/// <param name="args">An array of instances</param>
		/// <typeparam name="T">The type to create</typeparam>
		T Resolve<T>(params object[] args)
			where T : class;


		IEnumerable<T> ResolveAll<T>()
			where T : class;

		void Unregister<T>();
		void Unregister(Type t);
		/// <summary>
		/// Resolve by type
		/// </summary>
		/// <param name="t">The type</param>
		/// <param name="args">Arguments pass to the constructor.</param>
		object Resolve(Type t, params object[] args);
		/// <summary>
		/// Resolve by type
		/// </summary>
		/// <param name="t">The type</param>
		object Resolve(Type t);
		/// <summary>
		/// Resolve by class name
		/// </summary>
		/// <param name="name">The name of the class to resolve</param>
		/// <param name="args">Arguments passed to the constructor.</param>
		object Resolve(string name, params object[] args);
		/// <summary>
		/// Resolve by class name
		/// </summary>
		/// <param name="name">The name of the class to resolve.</param>
		object Resolve(string name);

		/// <summary>
		/// Fetch an object of type TIface
		/// <returns>An object implementing TIFace or null if no implementation is found</returns>
		/// </summary>
		/// <typeparam name="TIface">The type.</typeparam>
		T ResolveOrDefault<T>()
			where T : class;

		T ResolveOrDefault<T>(params object[] args)
			where T : class;

		/// <summary>
		/// Auto register classes with the AutoRegister attribute
		/// </summary>
		/// <remarks>
		/// Note that if the class should be resolved using and interface,
		/// the interface got to be the "first" in the inheritance chain
		/// and live in the same assembly as the class.
		/// </remarks>
		/// <param name="assembly">The assembly holding the classes</param>
		void AutoRegister(Assembly assembly);

		/// <summary>
		/// Check if a type is registered
		/// </summary>
		/// <returns><c>true</c>, if type registered, <c>false</c> otherwise.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		bool IsRegistered<T>();

		// Helpers
		IRegistryEntry GetEntry(string name);
		IEnumerable<IRegistryEntry> RegisteredEntries { get; }
		IEnumerable<Type> RegistedTypes { get; }
		IEnumerable<string> RegisteredNames { get; }
	}
}
