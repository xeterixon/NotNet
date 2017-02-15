using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace NotNet.Core
{
	/// <summary>
	/// Object lifecycle.
	/// </summary>
	public enum ObjectLifecycle
	{
		Transient,
		Singleton,
	}
	public class Container : IContainer
	{
		public static IContainer Default { get; private set; }
		private readonly Registry _registry;
		private readonly Resolver _resolver;
		private Container()
		{
			_registry = new Registry();
			_resolver = new Resolver(_registry);

		}
		static Container()
		{
			Default = new Container();
			// Register it self
			Default.RegisterSingleton(Default);

		}
		/// <summary>
		/// Register an interface and a implementing class
		/// </summary>
		/// <param name="olc">The lifecycle for the object.</param>
		/// <typeparam name="TIface">The interface.</typeparam>
		/// <typeparam name="TImpl">The implementation.</typeparam>
		public void Register<TIface, TImpl>(ObjectLifecycle olc = ObjectLifecycle.Transient)
			where TIface : class
			where TImpl : TIface
		{
			var ift = typeof(TIface);
			var imt = typeof(TImpl);
			_registry.Add(ift, imt, olc);
		}
		public void Register<TImpl>(ObjectLifecycle olc = ObjectLifecycle.Transient)
			where TImpl : class
		{
			_registry.Add(typeof(TImpl), typeof(TImpl), olc);
		}
		/// <summary>
		/// Register an interface and a implementing class as a singleton
		/// </summary>
		/// <typeparam name="TIface">The interface.</typeparam>
		/// <typeparam name="TImpl">The implementation.</typeparam>
		public void RegisterSingleton<TIface, TImpl>()
			where TIface : class
			where TImpl : TIface
		{
			Register<TIface, TImpl>(ObjectLifecycle.Singleton);
		}
		/// <summary>
		/// Registers an interface with an instansiated object.
		/// </summary>
		/// <param name="instance">The instance.</param>
		/// <typeparam name="TImpl">The interface.</typeparam>
		public void RegisterSingleton<TImpl>(TImpl instance)
			where TImpl : class
		{
			_registry.Add(typeof(TImpl), instance);
		}
		public T Resolve<T>(params object[] args)
			where T : class
		{
			return _resolver.CreateWithArguments<T>(args);
		}
		public IEnumerable<T> ResolveAll<T>()
			where T : class
		{
			return _resolver.CreateAll<T>();
		}
		public void Unregister<T>() 
		{
			Unregister(typeof(T));
		}

		public void Unregister(Type t) 
		{
			_registry.Remove(t);
		}

		/// <summary>
		/// Get the implementation for an interface.
		/// </summary>
		/// <typeparam name="TIface">The interface</typeparam>
		public TIface Resolve<TIface>()
			where TIface : class
		{
			return _resolver.Create<TIface>();
		}

		public T ResolveOrDefault<T>(params object[] args)
			where T : class

		{
			return _resolver.TryCreateWithArguments<T>(args);
		}
		public TIFace ResolveOrDefault<TIFace>()
			where TIFace : class
		{
			return _resolver.TryCreate<TIFace>();
		}
		public void AutoRegister(Assembly assembly)
		{
			// Register "SomeClass" that implements "ISomeClass"
			var attr = typeof(AutoRegisterAttribute);
			var typeInfos = assembly.DefinedTypes.Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute(attr) != null).ToList();
			foreach (var typeInfo in typeInfos) {
				try {
					var autoattr = typeInfo.GetCustomAttribute(attr) as AutoRegisterAttribute;
					var iface = autoattr.Description == ObjectDescription.ImplementsInterface ?
										typeInfo.AsType().GetTypeInfo().ImplementedInterfaces.FirstOrDefault() :
										typeInfo.AsType();
					Register(iface, typeInfo.AsType(), autoattr.Lifecycle);
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
			}
		}
		private void Register(Type iface, Type impl, ObjectLifecycle olc)
		{
			_registry.Add(iface, impl, olc);
		}
		public object Resolve(Type t, params object[] args)		{
			return _resolver.CreateWithArguments(t, args);
		}
		public object Resolve(Type t)		{
			return _resolver.Create(t);
		}
		public object Resolve(string name) 
		{
			return _resolver.Create(name);	
		}
		public object Resolve(string name, params object[] args)
		{
			return _resolver.CreateWithArguments(name, args);
		}

		public object GetService(Type serviceType)
		{
			return _resolver.Create(serviceType);
		}
		public bool IsRegistered<T>()
		{
			return _registry.IsRegistered<T>();
		}

		public IEnumerable<Type> RegistedTypes
		{
			get { 
				return _registry.Register.Select((arg) => arg.Key);
			}
		}
		public IRegistryEntry GetEntry(string name) 
		{
			var tmp =  _registry.Register.FirstOrDefault((arg) => arg.Key.Name == name);
			return tmp.Value?.FirstOrDefault();
		}

		public IEnumerable<string> RegisteredNames
		{
			get {
				return _registry.Register.Select((arg) => arg.Key.Name);
			}
		}
		public IEnumerable<IRegistryEntry> RegisteredEntries 
		{
			get {
				return _registry.Register.SelectMany((arg) => arg.Value);
			}
		}

	}
}

