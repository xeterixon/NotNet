using NotNet.Core;

namespace NNFTests
{
	public interface ITestModel1
	{
		string Name { get; }
	}
	[AutoRegister]
	public class TestModel1 : ITestModel1
	{
		public string Name { get; set; } = "Some Random Text";
	}
}
