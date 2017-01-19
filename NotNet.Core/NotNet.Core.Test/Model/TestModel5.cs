using System;
namespace NotNet.Core.Test.Model
{
	public class TestModel5
	{
		public string Test1 { get; set; } = Guid.NewGuid().ToString();
		public string Test2 { get; set; } = "TestModel5.Test2";
	}
}
