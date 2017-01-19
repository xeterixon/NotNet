using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NotNet.Core
{
	// internal holder of stuff
	internal class RegistryEntry
	{
		public Type Interface{get;set;}
		public Type Implementation{get;set;}
		public object Instance{get;set;}
		public ObjectLifecycle LifeCycle{ get; set; }
	}
	internal class Registry
	{
		public Registry()
		{
			RegisteredTypes = new List<RegistryEntry> ();
		}
		public IList<RegistryEntry> RegisteredTypes{ get; private set;}
		public void Add(Type iface, object instance)
		{
			RegisteredTypes.Add(new RegistryEntry{ Instance = instance, Implementation = instance.GetType(), Interface = iface, LifeCycle = ObjectLifecycle.Singleton});
		}
		public void Add(Type iface, Type impl, ObjectLifecycle olc)
		{
			if (!iface.Equals(impl) && !iface.GetTypeInfo ().IsInterface) 
			{
				throw new ArgumentException (string.Format("{0} is not an interface", iface.Name));
			}

			if(!iface.GetTypeInfo ().IsAssignableFrom (impl.GetTypeInfo ()))
			{
				throw new ArgumentException (string.Format("{0} does not implement {1}",impl.Name,iface.Name));
			}
			if (RegisteredTypes.Any (r => r.Interface.Equals (iface))) 
			{
				throw new ArgumentException(string.Format("{0} is already registered",iface.Name));
			}
			lock (RegisteredTypes) 
			{
				RegisteredTypes.Add (new RegistryEntry{ Interface = iface, Implementation = impl , LifeCycle = olc });
			}
		}

	}
}

