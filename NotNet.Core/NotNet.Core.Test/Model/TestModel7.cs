using System;
namespace NotNet.Core.Test.Model
{
	#region Non regsistered classes
	public class TestArg1 
	{
		public string ArgTest { get; set; } = Guid.NewGuid().ToString();
	}
	public class TestArg2
	{
		public string ArgTest { get; set; } = Guid.NewGuid().ToString();
	}
	public class TestArg3 : TestArg2
	{
		public string ArgTest3 { get; set; } = Guid.NewGuid().ToString();
	}
	#endregion
	public class TestModel7
	{

		public string Test 
		{
			get { return $"{_arg1.ArgTest} - {_model1.Test1}";}
		}
		TestArg1 _arg1;
		ITestModel1 _model1;
		public TestModel7(ITestModel1 model1, TestArg1 arg1, TestArg2 arg2)
		{
			_arg1 = arg1;
			_model1 = model1;
		}
	}
}
