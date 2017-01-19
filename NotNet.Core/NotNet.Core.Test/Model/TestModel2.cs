using System;
namespace NotNet.Core.Test.Model
{
	public interface ITestModel2
	{
		string Test1 { get; set; }
		string Test2 { get; set; }
	}
	public class TestModel2 : ITestModel2
	{
		public string Test1 { get; set; } = Guid.NewGuid().ToString();
		public string Test2 { get; set; } = "TestModel2.Test2";

	}
}
