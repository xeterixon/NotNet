using System;
namespace NotNet.Core
{
	/// <summary>
	/// Preferred constructor attribute.
	/// If a class has more than one constructor, use this attribute to mark 
	/// which constructor that should be used when constructing.
	/// </summary>
	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
	public class PreferredConstructorAttribute : Attribute
	{
	}
}
