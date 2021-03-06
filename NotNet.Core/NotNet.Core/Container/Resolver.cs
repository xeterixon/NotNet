﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NotNet.Core
{
	internal sealed class Resolver
	{
		Registry _registry;
		public Resolver(Registry registry)
		{
			_registry = registry;
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
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				return null;
			}
		}
		public object CreateWithArguments(Type t, params object[] args)
		{
			return CreateWithArguments(t.Name, args);
		}

		#region Private
		RegistryEntry GetEntryFor(Type t, Type implementationHint)
		{
			var tmp = _registry.Register.FirstOrDefault(r => r.Key.Equals(t));
			return tmp.Value?.FirstOrDefault((arg) => arg.Implementation.Equals(implementationHint) || implementationHint == null);
		}
		RegistryEntry GetEntryFor(string name)
		{
			return _registry.Register.FirstOrDefault((arg) => arg.Key.Name == name).Value.FirstOrDefault();
		}

		internal object Build(Type ifaceType, Type implementationHint = null)
		{
			var entry = GetEntryFor(ifaceType, implementationHint);
			if(entry == null) return null;
			if(entry.LifeCycle == ObjectLifecycle.Singleton)
			{
				if(entry.Instance == null)
					entry.Instance = FindBestConstructorAndCreateInstance(entry.Implementation);
				return entry.Instance;
			}
			var instance = FindBestConstructorAndCreateInstance(entry.Implementation);
			if(entry.Callback != null)
			{
				entry.Callback.Invoke(instance);
			}
			return instance;
		}

		internal object CreateWithArguments(string name, params object[] args)
		{
			var entry = GetEntryFor(name);
			var ctor = GetPreferredConstructor(entry.Implementation);
			var instance = CreateInstanceWithArguments(ctor, args);
			if(entry.Callback != null)
			{
				entry.Callback.Invoke(instance);
			}
			return instance;
		}
		internal object Create(string name)
		{
			var entry = GetEntryFor(name);
			return Build(entry.Interface);
		}
		internal IEnumerable<T> CreateAll<T>()
		{
			var list = new List<T>();
			var entries = _registry.Register[typeof(T)];
			foreach(var entry in entries)
			{
				list.Add((T)Build(entry.Interface, entry.Implementation));
			}
			return list;
		}
		internal object Create(Type t)
		{
			return Build(t);
		}
		internal TIface Create<TIface>()
			where TIface : class
		{
			var it = TryCreate<TIface>();
			if(it == null)
			{
				throw new ArgumentException($"Unable to resolve {typeof(TIface).GetTypeInfo().Name}");
			}
			return it;
		}
		internal T CreateWithArguments<T>(params object[] args)
		{
			return (T)CreateWithArguments(typeof(T), args);
		}
		ConstructorInfo GetPreferredConstructor(Type type)
		{
			var ctors = type.GetTypeInfo().DeclaredConstructors.OrderBy((arg) => arg.GetParameters().Count());
			var ctor = ctors.FirstOrDefault((arg) => arg.GetCustomAttribute(typeof(PreferredConstructorAttribute)) != null) ?? ctors.FirstOrDefault();
			return ctor;
		}
		object CreateInstanceWithArguments(ConstructorInfo cinof, params object[] args)
		{
			var cargs = GetResolvableArguments(cinof);
			cargs.AddRange(args);
			return Activator.CreateInstance(cinof.DeclaringType, cargs.ToArray());
		}
		List<object> GetResolvableArguments(ConstructorInfo cinfo)
		{
			var types = new List<object>();
			foreach(var param in cinfo.GetParameters())
			{
				var t = param.ParameterType;
				var o = Build(t);
				if(o != null)
				{
					types.Add(o);
				}
			}
			return types;
		}
		object CreateInstance(ConstructorInfo cinfo)
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
		object FindBestConstructorAndCreateInstance(Type type)
		{

			var ctor = GetPreferredConstructor(type);
			return CreateInstance(ctor);
		}
		#endregion

	}
}
