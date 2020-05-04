using System;
namespace NotNet.Core.UnitTest
{
	public class SingletonModel1
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}
