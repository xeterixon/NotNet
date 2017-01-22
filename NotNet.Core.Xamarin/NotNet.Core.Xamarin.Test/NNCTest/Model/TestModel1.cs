using System;
using NotNet.Core;

namespace NNCTest
{
	[AutoRegister(ObjectDescription.NoInterface)]
	public class TestModel1
	{
		public string Test { get; set; }
		public TestModel1()
		{
			Test = Guid.NewGuid().ToString();
		}
	}
}
