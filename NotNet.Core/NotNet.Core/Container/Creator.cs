using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NotNet.Core
{
	internal class Creator
	{
		private Registry _registry;
		public Creator(Registry registry) 
		{
			_registry = registry;
		}
		private RegistryEntry GetEntryFor(Type t) 
		{
			return  _registry.RegisteredTypes.FirstOrDefault(r => r.Interface.Equals(t));
			
		}
		public TIface TryCreate<TIface>()
			where TIface : class
		{
			try
			{
				return CreateObject(typeof(TIface)) as TIface;
			}
            catch 
			{
				return null;
			}
		}
		internal object CreateObject(Type ifaceType) 
		{
			var entry = GetEntryFor(ifaceType);
			if (entry == null) return null;
			if (entry.LifeCycle == ObjectLifecycle.Singleton) {
				if (entry.Instance == null)
					entry.Instance = FindBestConstructorAndCreateInstance(entry.Implementation);
				return entry.Instance;
			} else 
			{
				return FindBestConstructorAndCreateInstance(entry.Implementation);
			}
		}
		public object Create(Type t) 
		{
			return CreateObject(t);
		}
		public TIface Create<TIface>()
			where TIface : class
		{
			var it = TryCreate<TIface>();
			if (it == null) {
				throw new ArgumentException(string.Format("Type {0} is not registered", typeof(TIface).GetTypeInfo().Name));
			}
			return it;
		}
		/// <summary>
		/// Finds the best constructor and create instance.
		/// It tries to use the constructor with the least amount of parameters 
		/// or the one marked as prefered contstructor
		/// </summary>
		/// <returns>An object of some description.</returns>
		/// <param name="type">Type.</param>
		private object FindBestConstructorAndCreateInstance(Type type) 
		{
			var bt = type.GetTypeInfo().BaseType;

			var ctors = type.GetTypeInfo().DeclaredConstructors.OrderBy((arg) => arg.GetParameters().Count());
			var ctor = ctors.FirstOrDefault((arg) => arg.GetCustomAttribute(typeof(PreferredConstructorAttribute)) != null) ?? ctors.FirstOrDefault();
			List<object> types = new List<object>();
			foreach (var param in ctor.GetParameters()) 
			{
				var t = param.ParameterType;
				var o = CreateObject(t);
				types.Add(o);
			}
			return Activator.CreateInstance(type, types.ToArray());
		}
	}
}
