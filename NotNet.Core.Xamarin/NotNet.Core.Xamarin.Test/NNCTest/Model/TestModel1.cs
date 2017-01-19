using System;
using NotNet.Core;

namespace NNCTest
{
	[AutoRegisterModel(true)]
	public class TestModel1
	{
		public string Test { get; set; }
		public TestModel1()
		{
			Test = Guid.NewGuid().ToString();
		}
	}
}
