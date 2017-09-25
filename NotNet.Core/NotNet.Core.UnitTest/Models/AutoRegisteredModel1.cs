using System;
namespace NotNet.Core.UnitTest
{
	[AutoRegister]
	public class AutoRegisteredModel1
	{
		public string Name { get; set; } = nameof(AutoRegisteredModel1);
	}
}
