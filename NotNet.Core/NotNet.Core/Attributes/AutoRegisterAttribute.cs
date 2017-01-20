using System;
namespace NotNet.Core
{
	/// <summary>
	/// Should be used when register a Class that implements an specified interface.
	/// </summary>
	[System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class AutoRegisterAttribute : Attribute
	{
		public bool AsSingleton{ get; set;}
		public AutoRegisterAttribute (bool asSingleton = false)
		{
			AsSingleton = asSingleton;
		}
	}
	/// <summary>
	/// Should be used when register a Class without a specified interface
	/// </summary>
	[System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class AutoRegisterBaseAttribute : Attribute
	{
		public bool AsSingleton { get; set; }
		public AutoRegisterBaseAttribute(bool asSingleton = false)
		{
			AsSingleton = asSingleton;
		}
	}
}

