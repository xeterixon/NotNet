using System;
namespace NotNet.Core
{
	public enum ObjectDescription 
	{
		NoInterface = 0,
		HasInterface = 1

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
			Lifecycle = ObjectLifecycle.NewInstance;
			Description = ObjectDescription.HasInterface;
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

