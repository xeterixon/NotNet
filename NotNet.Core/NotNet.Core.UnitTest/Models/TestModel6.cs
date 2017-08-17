using System;
namespace NotNet.Core.UnitTest
{
	[AutoRegister]
	public class TestModel6
	{
		public SingletonModel1 Single { get; private set;}
		public NonRegisteredModel Arg { get; private set;}
		public TestModel6( SingletonModel1 single, NonRegisteredModel model)
		{
			Single = single;
			Arg = model;
		}
	}
}
