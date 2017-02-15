using System;
namespace NotNet.Core.UnitTest
{
	[AutoRegister(ObjectDescription.Base)]	
	public class TestModel5
	{
		public SingletonModel1 Single { get; private set;}  
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public TestModel5(SingletonModel1 single) 
		{
			Single = single;
		}
	}
}
