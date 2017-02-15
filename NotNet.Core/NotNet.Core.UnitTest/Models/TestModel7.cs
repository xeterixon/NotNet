using System;
namespace NotNet.Core.UnitTest
{
	public interface ITestModel7 
	{
		string Name { get; }
	}
	[AutoRegister]
	public class TestModel7 : ITestModel7
	{
		public string Name { get; private set; } = nameof(TestModel7);
	}
}
