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
			Container.Default.RegisterTransient<ITestModel1, TestModel1>();
			Container.Default.RegisterSingleton<SingletonModel1>();
			Container.Default.RegisterTransient<IMulti, Multi1>();
			Container.Default.RegisterTransient<IMulti, Multi2>();

		}
		[OneTimeTearDown]
		public void TearDown()
		{
		}
	}
}
