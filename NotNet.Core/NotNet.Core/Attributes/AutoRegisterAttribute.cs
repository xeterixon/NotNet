using System;
namespace NotNet.Core
{
	/// <summary>
	/// Should be used when register a Class that implements an specified interface.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class AutoRegisterAttribute : Attribute
	{
		public ObjectLifecycle Lifecycle { get; private set; }
		public AutoRegisterAttribute() : this(ObjectLifecycle.Transient) { }
		public AutoRegisterAttribute(ObjectLifecycle life)
		{
			Lifecycle = life;
		}
	}
}

