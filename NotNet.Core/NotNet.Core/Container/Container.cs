using System;
using System.Reflection;
using System.Linq;

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
		public static IContainer Default { get; private set;}
		private readonly Registry _registry;
		private readonly Creator _createor;
		private Container() 
		{
			_registry = new Registry();
			_createor = new Creator(_registry);

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
		public void Register<TIface,TImpl>( ObjectLifecycle olc = ObjectLifecycle.Transient)
			where TIface:class
			where TImpl:TIface
		{
			var ift = typeof(TIface);
			var imt = typeof(TImpl);
			_registry.Add (ift, imt,olc);
		}
		public void Register<TImpl>(ObjectLifecycle olc = ObjectLifecycle.Transient) 
			where TImpl:class
		{
			_registry.Add(typeof(TImpl), typeof(TImpl), olc);
		}
		/// <summary>
		/// Register an interface and a implementing class as a singleton
		/// </summary>
		/// <typeparam name="TIface">The interface.</typeparam>
		/// <typeparam name="TImpl">The implementation.</typeparam>
		public void RegisterSingleton<TIface,TImpl>()
			where TIface:class
			where TImpl:TIface
		{
			Register<TIface,TImpl> (ObjectLifecycle.Singleton);
		}
		/// <summary>
		/// Registers an interface with an instansiated object.
		/// </summary>
		/// <param name="instance">The instance.</param>
		/// <typeparam name="TImpl">The interface.</typeparam>
		public void RegisterSingleton<TImpl>(TImpl instance)
			where TImpl:class
		{
			_registry.Add(typeof(TImpl), instance);	
		}
		/// <summary>
		/// Get the implementation for an interface.
		/// </summary>
		/// <typeparam name="TIface">The interface</typeparam>
		public TIface Resolve<TIface>()
			where TIface:class
		{
			return _createor.Create<TIface>();
		}
		/// <summary>
		/// Get the implementation for an interface
		/// </summary>
		/// <param name="action">A action to call after the creation of the object</param>
		/// <typeparam name="TIface">The interface.</typeparam>
		public TIface Resolve<TIface>(Action<TIface> action)
			where TIface:class
		{
			var obj = _createor.Create<TIface> ();
			action (obj);
			return obj;
		}
		public TIFace ResolveOrDefault<TIFace>()
			where TIFace:class
		{
			return _createor.TryCreate<TIFace>();
		}
		public void AutoRegister(Assembly assembly)
		{
			// Register "SomeClass" that implements "ISomeClass"
			var attr = typeof(AutoRegisterAttribute);
			var typeInfos = assembly.DefinedTypes.Where (t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute(attr) != null).ToList();
			foreach (var typeInfo in typeInfos) 
			{
				try
				{
					var autoattr = typeInfo.GetCustomAttribute(attr) as AutoRegisterAttribute;
					var iface = autoattr.Description == ObjectDescription.ImplementsInterface ?
										typeInfo.AsType().GetTypeInfo().ImplementedInterfaces.FirstOrDefault() :
										typeInfo.AsType();
					Register(iface,typeInfo.AsType(),autoattr.Lifecycle);
				}
				catch(Exception ex)
				{
					System.Diagnostics.Debug.WriteLine (ex.Message);
				}
			}
		}
		private void Register(Type iface, Type impl, ObjectLifecycle olc)
		{
			_registry.Add (iface, impl, olc);
		}

		public object GetService(Type serviceType)
		{
			return _createor.Create(serviceType);
		}
		public bool IsRegistered<T>() 
		{
			return _registry.IsRegistered<T>();
		}
	}
}

