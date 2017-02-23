using System;
namespace NotNet.Core.UnitTest
{
	[AutoRegister(ObjectDescription.Base)]
	public class TestModel4
	{
		public string ModelName { get { return Model.Name; } }
		public AutoRegisteredModel1 Model { get; private set;}
		public TestModel4(AutoRegisteredModel1 model )
		{
			Model = model;
		}
	}
}
