using System;
using System.Collections.Generic;
using NotNet.Core;

namespace NNCTest
{
	[AutoRegister(ObjectLifecycle.Singleton)]
	public class ObjectRegistry : IObjectRegistry
	{
		private Dictionary<Type, object> _registry;
		public ObjectRegistry()
		{
			_registry = new Dictionary<Type, object>();
		}

		public T GetInstance<T>()
		{
			object obj;
			_registry.TryGetValue(typeof(T), out obj);
			return (T)obj;
		}

		public void SetInstance<T>(T instance)
		{
			if (!_registry.ContainsKey(typeof(T))) 
			{
				_registry.Add(typeof(T), instance);
			}
			_registry[typeof(T)] = instance;
		}
	}
}
