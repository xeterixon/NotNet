using System;
using NotNet.Core;

namespace NotNet.Core.Test.Model
{
	public interface ITestModel1 
	{
		string Test1 { get; set; } 
		string Test2 { get; set; }
	}
	// Singleton
	[AutoRegister(ObjectLifecycle.Singleton)]
	public class TestModel1: ITestModel1
	{
		public string Test1 { get; set; } = Guid.NewGuid().ToString();
		public string Test2 { get; set; } = "TestModel1.Test2";
	}
}
