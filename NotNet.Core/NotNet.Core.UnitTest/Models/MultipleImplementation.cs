using System;
namespace NotNet.Core.UnitTest
{
	public interface IMulti
	{
		string Name { get; }
	}

	public class Multi1 : IMulti 
	{
		public string Name { get; set; } = nameof(Multi1);
	}
	public class Multi2 : IMulti
	{
		public string Name { get; set; } = nameof(Multi2);
		
	}

}
