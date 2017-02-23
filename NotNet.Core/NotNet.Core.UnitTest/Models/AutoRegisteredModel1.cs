using System;
namespace NotNet.Core.UnitTest
{
	[AutoRegister(ObjectDescription.Base)]
	public class AutoRegisteredModel1
	{
		public string Name { get; set; } = nameof(AutoRegisteredModel1);
	}
}
