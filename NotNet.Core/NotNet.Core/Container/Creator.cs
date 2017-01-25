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
		public T TryCreateWithArgs<T>(params object[] args) 
		{
			try 
			{
				return CreateWithArguments<T>(args);
			} 
			catch 
			{
				return default(T);
			}
		}
		public TIface TryCreate<TIface>()
			where TIface : class
		{
			try
			{
				return Build(typeof(TIface)) as TIface;
			}
            catch 
			{
				return null;
			}
		}
		internal object Build(Type ifaceType) 
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
		public object CreateWithArgs(Type t, params object[] args) 
		{
			var ctor = GetPreferredConstructor(t);
			return CreateInstanceWithArguments(ctor, args);
		}
		public object Create(Type t) 
		{
			return Build(t);
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
		public T CreateWithArguments<T>(params object[] args) 
		{
			return (T)CreateWithArgs(typeof(T), args);
		}
		private ConstructorInfo GetPreferredConstructor(Type type) 
		{
			var ctors = type.GetTypeInfo().DeclaredConstructors.OrderBy((arg) => arg.GetParameters().Count());
			var ctor = ctors.FirstOrDefault((arg) => arg.GetCustomAttribute(typeof(PreferredConstructorAttribute)) != null) ?? ctors.FirstOrDefault();
			return ctor;
		}
		private object CreateInstanceWithArguments(ConstructorInfo cinof, params object[] args) 
		{
			var cargs = GetInjectedArguments(cinof);
			cargs.AddRange(args);
			return Activator.CreateInstance(cinof.DeclaringType, cargs.ToArray());
		}
		private List<object> GetInjectedArguments(ConstructorInfo cinfo) 
		{
			List<object> types = new List<object>();
			foreach (var param in cinfo.GetParameters()) {
				var t = param.ParameterType;
				var o = Build(t);
				if (o != null)
				{
					types.Add(o);
				}
			}
			return types;
		}
		private object CreateInstance(ConstructorInfo cinfo) 
		{
			var args = GetInjectedArguments(cinfo);
			return Activator.CreateInstance(cinfo.DeclaringType, args.ToArray());
			
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

			var ctor = GetPreferredConstructor(type);
			return CreateInstance(ctor);
		}
	}
}
