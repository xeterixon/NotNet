using System;
using NotNet.Core.Attributes;

namespace NotNet.Core.Test.Model
{
	interface ITestModel4 
	{
		string Test1 { get; set; }
		string Test2 { get; set; }
	}
	[AutoRegister]
	public class TestModel4 : ITestModel4
	{
		ITestModel2 _m2;
		ITestModel1 _m1;
		ITestModel3 _m3;
		public TestModel4(ITestModel1 m1, ITestModel2 m2, ITestModel3 m3)
		{
			_m1 = m1;
			_m2 = m2;
			_m3 = m3;
		}
		public string Test1 {
			get { return _m3.Test1; }
			set { _m3.Test1 = value;}
		}
		public string Test2 {
			get { return _m2.Test1; }
			set { _m2.Test1 = value; }
		}

	}
}
