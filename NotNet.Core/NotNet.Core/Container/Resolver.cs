﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NotNet.Core
{
	internal class Resolver
	{
		private Registry _registry;
		public Resolver(Registry registry) 
		{
			_registry = registry;
		}
		private RegistryEntry GetEntryFor(Type t) 
		{
			return  _registry.RegisteredTypes.FirstOrDefault(r => r.Interface.Equals(t));
		}
		private RegistryEntry GetEntryFor(string name) 
		{
			return _registry.RegisteredTypes.FirstOrDefault((arg) => arg.Interface.Name == name);
		}
		public T TryCreateWithArguments<T>(params object[] args) 
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
		public object CreateWithArguments(Type t, params object[] args) 
		{
			var ctor = GetPreferredConstructor(t);
			return CreateInstanceWithArguments(ctor, args);
		}
		internal object CreateWithArguments(string name, params object[] args) 
		{
			var ctor = GetPreferredConstructor(GetEntryFor(name).Interface);
			return CreateInstanceWithArguments(ctor, args);
		}
		internal object Create(string name) 
		{
			var entry = GetEntryFor(name);
			return Build(entry.Interface);
		}
		internal object Create(Type t) 
		{
			return Build(t);
		}
		internal TIface Create<TIface>()
			where TIface : class
		{
			var it = TryCreate<TIface>();
			if (it == null) {
				throw new ArgumentException(string.Format("Unable to resolve {0}", typeof(TIface).GetTypeInfo().Name));
			}
			return it;
		}
		internal T CreateWithArguments<T>(params object[] args) 
		{
			return (T)CreateWithArguments(typeof(T), args);
		}
		private ConstructorInfo GetPreferredConstructor(Type type) 
		{
			var ctors = type.GetTypeInfo().DeclaredConstructors.OrderBy((arg) => arg.GetParameters().Count());
			var ctor = ctors.FirstOrDefault((arg) => arg.GetCustomAttribute(typeof(PreferredConstructorAttribute)) != null) ?? ctors.FirstOrDefault();
			return ctor;
		}
		private object CreateInstanceWithArguments(ConstructorInfo cinof, params object[] args) 
		{
			var cargs = GetResolvableArguments(cinof);
			cargs.AddRange(args);
			return Activator.CreateInstance(cinof.DeclaringType, cargs.ToArray());
		}
		private List<object> GetResolvableArguments(ConstructorInfo cinfo) 
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
			var args = GetResolvableArguments(cinfo);
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
