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
			Container.Default.AutoRegister(typeof(Config).GetTypeInfo().Assembly);
			Container.Default.Register<ITestModel1, TestModel1>();
			Container.Default.Register<SingletonModel1>(ObjectLifecycle.Singleton);
			Container.Default.Register<IMulti, Multi1>();
			Container.Default.Register<IMulti, Multi2>();

		}
		[OneTimeTearDown]
		public void TearDown()
		{
		}
	}
}
