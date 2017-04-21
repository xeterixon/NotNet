using System;
using NotNet.Core;
using NotNet.Core.Forms;

namespace NNFTests
{
	public interface ITestModel1
	{
		string Name { get; }
	}
	[AutoRegister]
	public class TestModel1 : ITestModel1
	{
		public TestModel1(ITimer timer) 
		{
			timer.StartTimer(TimeSpan.FromSeconds(2), () => 
			{
				System.Diagnostics.Debug.WriteLine("In timer");
				return false;
			});
		}
		public string Name { get; set; } = "Some Random Text";
	}
}
