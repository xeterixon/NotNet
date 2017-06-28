using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NotNet.Core
{
	class Registry
	{
		public Dictionary<Type, List<RegistryEntry>> Register = new Dictionary<Type, List<RegistryEntry>>();
		readonly object gate = new object();
		public bool IsRegistered<T>()
		{
			return Register.Any((arg) => arg.Key.Equals(typeof(T)));
		}


		//TODO There should be a lock in the Add methods
		public void Add(Type iface, object instance)
		{
			if (!Register.Keys.Contains(iface)) 
			{
				Register.Add(iface, new List<RegistryEntry>());
			}
			Register[iface].Add(
				new RegistryEntry 
				{ 
					Instance = instance, 
					Implementation = instance.GetType(), 
					Interface = iface, 
					LifeCycle = ObjectLifecycle.Singleton 
				}
			);
		}
		public void Remove(Type t) 
		{
			var items = Register.Where((arg) => arg.Key.Equals(t)).ToList();
			foreach (var item in items) 
			{
				Register.Remove(item.Key);
			}
		}
		public void Add<T>(Type iface, Type impl, ObjectLifecycle olc, Action<T> callback) 
		{
			if (!iface.Equals(impl) && !iface.GetTypeInfo().IsInterface)
			{
				throw new ArgumentException(string.Format("{0} is not an interface", iface.Name));
			}

			if (!iface.GetTypeInfo().IsAssignableFrom(impl.GetTypeInfo()))
			{
				throw new ArgumentException(string.Format("{0} does not implement {1}", impl.Name, iface.Name));
			}
			lock (gate)
			{
				if (!Register.Keys.Contains(iface))
				{
					Register.Add(iface, new List<RegistryEntry>());
				}
				var wrappedCallback = callback != null ? new Action<object>((obj) => callback((T)obj)) : null;
				Register[iface].Add(new RegistryEntry { 
					Interface = iface, 
					Implementation = impl, 
					LifeCycle = olc, 
					Callback = wrappedCallback 
				});
			}
			
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
			lock (gate) 
			{
				if (!Register.Keys.Contains(iface)) 
				{
					Register.Add(iface, new List<RegistryEntry>());
				}
				Register[iface].Add(new RegistryEntry { Interface = iface, Implementation = impl, LifeCycle = olc });
			}
		}

	}
}

