using System;
namespace NotNet.Core
{
	[System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class AutoRegisterAttribute : Attribute
	{
		public bool AsSingleton{ get; set;}
		public AutoRegisterAttribute (bool asSingleton = false)
		{
			AsSingleton = asSingleton;
		}
	}
	[System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class AutoRegisterModelAttribute : Attribute
	{
		public bool AsSingleton { get; set; }
		public AutoRegisterModelAttribute(bool asSingleton = false)
		{
			AsSingleton = asSingleton;
		}
	}
}

