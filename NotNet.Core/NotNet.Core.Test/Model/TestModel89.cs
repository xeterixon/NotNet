using System;
namespace NotNet.Core.Test.Model
{
	public interface ITestModel89 
	{
		string Name { get; set; }
	}
	public class TestModel8 : ITestModel89
	{
		public TestModel8(ITestModel2 m)
		{
			Name = "TM8 " + m.Test1;
		}
		public string Name { get; set; } 
	}
	public class TestModel9 : ITestModel89 
	{
		public TestModel9(ITestModel1 m) 
		{
			Name = "TM9 " + m.Test1;
		}
		public string Name { get; set; } 
	}
}
