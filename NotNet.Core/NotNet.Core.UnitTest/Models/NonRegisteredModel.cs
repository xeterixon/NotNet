using System;
namespace NotNet.Core.UnitTest
{
	public class NonRegisteredModel
	{
		public string Name { get; private set;}
		public NonRegisteredModel(string name)
		{
			Name = name;
		}
	}
}
