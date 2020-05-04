using System.Reflection;
using NUnit.Framework;

namespace NotNet.Core.UnitTest
{
	[SetUpFixture]
	public class Config
	{
		[OneTimeSetUp]
		public void Setup()
		{
            ContainerConfigurator.Configure(Container.Default)
                                  .AutoRegister<Config>()
                                  .RegisterTransient<ITestModel1, TestModel1>()
                                  .RegisterSingleton<SingletonModel1>()
                                  .RegisterTransient<IMulti, Multi1>()
                                  .RegisterTransient<IMulti, Multi2>();

		}
		[OneTimeTearDown]
		public void TearDown()
		{
		}
	}
}
