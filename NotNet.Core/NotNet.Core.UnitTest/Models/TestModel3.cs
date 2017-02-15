using System;
namespace NotNet.Core.UnitTest
{
	[AutoRegister(ObjectDescription.Base)]
	public class TestModel3
	{
		public string Name { get; set; } = nameof(TestModel3);
	}
}
