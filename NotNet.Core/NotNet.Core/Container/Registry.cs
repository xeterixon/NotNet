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

		public void Add(Type iface, object instance)
		{
			DoRegister(iface, instance.GetType(), instance, ObjectLifecycle.Singleton, null);
		}
		public void Remove(Type t)
		{
			var items = Register.Where((arg) => arg.Key.Equals(t)).ToList();
			foreach(var item in items)
			{
				Register.Remove(item.Key);
			}
		}
		public void Add<T>(Type iface, Type impl, ObjectLifecycle olc, Action<T> callback)
		{
			CheckTypes(iface, impl);
			var wrappedCallback = callback != null ? new Action<object>((obj) => callback((T)obj)) : null;
			DoRegister(iface, impl, null, olc, wrappedCallback);
		}
		public void Add(Type iface, Type impl, ObjectLifecycle olc)
		{
			CheckTypes(iface, impl);
			DoRegister(iface, impl, null, olc, null);
		}
		private void CheckTypes(Type iface, Type impl)
		{
			if(!iface.Equals(impl) && !iface.GetTypeInfo().IsInterface)
			{
				throw new ArgumentException(string.Format("{0} is not an interface", iface.Name));
			}

			if(!iface.GetTypeInfo().IsAssignableFrom(impl.GetTypeInfo()))
			{
				throw new ArgumentException(string.Format("{0} does not implement {1}", impl.Name, iface.Name));
			}

		}

		private void DoRegister(Type iface, Type impl, object instance, ObjectLifecycle olc, Action<object> callback)
		{
			lock(gate)
			{
				if(!Register.Keys.Contains(iface))
				{
					Register.Add(iface, new List<RegistryEntry>());
				}
				Register[iface].Add(new RegistryEntry { Interface = iface, Implementation = impl, Instance = instance, LifeCycle = olc, Callback = callback });
			}

		}

	}
}

