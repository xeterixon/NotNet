using System;
using NotNet.Core.Attributes;

namespace NotNet.Core.Test.Model
{
	public interface ITestModel3 
	{
		string Test1 { get; set; }
		string Test2 { get; set; }
	}
	[AutoRegister]
	public class TestModel3 : ITestModel3
	{
		public ITestModel1 Model1 { get; private set;}
		public TestModel3(ITestModel1 model)
		{
			Model1 = model;
		}
		public string Test1 
		{ 
			get { return "M1:" + Model1.Test1;}
			set { Model1.Test1 = "M1:" + value; }
		} 
		public string Test2 { get; set; } = "TestModel3.Test2";

	}
}
