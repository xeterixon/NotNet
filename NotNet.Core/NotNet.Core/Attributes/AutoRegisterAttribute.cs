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
	[System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class AutoRegisterAttribute : Attribute
	{
		public ObjectLifecycle Lifecycle{get; private set;}
		public ObjectDescription Description { get; private set;}
		public AutoRegisterAttribute() 
		{
			Lifecycle = ObjectLifecycle.Transient;
			Description = ObjectDescription.ImplementsInterface;
		}
		public AutoRegisterAttribute(ObjectLifecycle life) : this()
		{
			Lifecycle = life;
		}
		public AutoRegisterAttribute(ObjectDescription desc) : this()
		{
			Description = desc;
		}
		public AutoRegisterAttribute(ObjectLifecycle life, ObjectDescription desc)
		{
			Lifecycle = life;
			Description = desc;
		}
	}
}

