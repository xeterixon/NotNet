using System;
namespace NotNet.Core.UnitTest
{
	[AutoRegister(ObjectDescription.Base)]
	public class TestModel4
	{
		public string ModelName { get { return Model.Name; } }
		public TestModel3 Model { get; private set;}
		public TestModel4(TestModel3 model )
		{
			Model = model;
		}
	}
}
