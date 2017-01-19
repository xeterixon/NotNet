using System;
namespace NotNet.Core.Attributes
{
	public class AutoRegisterAttribute : Attribute
	{
		public bool AsSingleton{ get; set;}
		public AutoRegisterAttribute (bool asSingleton = false)
		{
			AsSingleton = asSingleton;
		}
	}
}

