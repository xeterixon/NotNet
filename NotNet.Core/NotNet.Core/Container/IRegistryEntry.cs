using System;
namespace NotNet.Core
{
	public interface IRegistryEntry
	{
		Type Interface { get;  }
		Type Implementation { get; }
		ObjectLifecycle LifeCycle { get; }
	}
	// internal holder of stuff
	internal class RegistryEntry : IRegistryEntry
	{
		public Type Interface { get; set; }
		public Type Implementation { get; set; }
		public object Instance { get; set; } // Holds the instance for singleton objects
		public ObjectLifecycle LifeCycle { get; set; }
	}
}
