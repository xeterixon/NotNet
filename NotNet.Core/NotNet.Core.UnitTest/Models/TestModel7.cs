using System;
namespace NotNet.Core.UnitTest
{
	public interface ITestModel7 
	{
		string Name { get; }
		ITestModel1 Model { get; }

	}
	[AutoRegister]
	public class TestModel7 : ITestModel7
	{
		public ITestModel1 Model { get; private set; }
		public string Name { get; private set; } = nameof(TestModel7);
		// The constructor with the least amount of argumenst are selected by default
		// Trying to override it with an attribute 
		public TestModel7() 
		{
			Model = null;
			throw new NotSupportedException("Default constructor should not be called");
		}
		[PreferredConstructor]
		public TestModel7(ITestModel1 _arg) 
		{
			Model = _arg;
			Name = nameof(Model);
		}
	}
}
