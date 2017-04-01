using System;
namespace NNFTests
{
	public interface ITestModel3 
	{
		void Init();
	}
	public class TestModel3 : ITestModel3
	{
		readonly ITestModel1 _m1;

		public TestModel3(ITestModel1 test1) 
		{
			_m1 = test1;
		}
		public void Init()
		{
			System.Diagnostics.Debug.WriteLine("In Init :" + _m1.Name);
		}
	}
}
