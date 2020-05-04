using System;
namespace NotNet.Core.UnitTest
{
	public interface IAutoRegisteredModel2 
	{
		string Name { get;}
	}
	[AutoRegister]
	public class AutoRegisteredModel2 : IAutoRegisteredModel2
	{
		public string Name { get; private set; } = nameof(AutoRegisteredModel2);
	}
}
