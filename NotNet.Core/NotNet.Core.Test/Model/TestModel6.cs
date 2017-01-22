using System;

namespace NotNet.Core.Test.Model
{
	[AutoRegister(ObjectDescription.NoInterface)]
	public class TestModel6
	{
		public TestModel5 Model { get; private set;}
		public string Test
		{
			get
			{
				return Model.Test1;
			}
			set
			{
				Model.Test1 = value;
			}
		}
		public TestModel6(TestModel5 md)
		{
			Model = md;
		}
	}
}
