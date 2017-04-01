using System;
namespace NotNet.Core
{
	public enum ObjectDescription 
	{
		Base = 0,
		ImplementsInterface = 1

	}
	/// <summary>
	/// Should be used when register a Class that implements an specified interface.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class AutoRegisterAttribute : Attribute
	{
		public ObjectLifecycle Lifecycle{get; private set;}
		public ObjectDescription Description { get; private set;}
		public AutoRegisterAttribute(bool isBase) : this(isBase ? ObjectDescription.Base : ObjectDescription.ImplementsInterface) { }
		public AutoRegisterAttribute() : this(ObjectLifecycle.Transient,ObjectDescription.ImplementsInterface){}
		public AutoRegisterAttribute(ObjectLifecycle life) : this(life, ObjectDescription.ImplementsInterface){}
		public AutoRegisterAttribute(ObjectDescription desc) : this(ObjectLifecycle.Transient,desc){}
		public AutoRegisterAttribute(ObjectLifecycle life, ObjectDescription desc)
		{
			Lifecycle = life;
			Description = desc;
		}
	}
}

