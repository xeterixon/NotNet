using System;
using NUnit.Framework;

namespace NotNet.Core.UnitTest
{
	[TestFixture]
	[Category("Dependecy injection tests")]

	public class DependecyInjection
	{
		[Test]
		public void InjectionTest1() 
		{
			var o = Container.Default.Resolve<TestModel4>();
			Assert.NotNull(o, "Should not be null");
			Assert.NotNull(o.Model, "Injected model should not be null");
			Assert.IsTrue(string.Compare(o.Model.Name, nameof(TestModel3)) == 0, "Injected model should be TestModel3");
		}
		[Test]
		public void InjectedModelShouldBeTheSame()
		{
			// TestModel5 should are Transient, while the dependent model is Singleton
			var o1 = Container.Default.Resolve<TestModel5>();
			var o2 = Container.Default.Resolve<TestModel5>();

			Assert.IsTrue(string.Compare(o1.Id, o2.Id) != 0, "Id should not be the same");
			Assert.IsTrue(string.Compare(o1.Single.Id, o2.Single.Id) == 0, "Injected Id should  be the same");

		}
		[Test]
		public void ResolveWithArgs() 
		{
			var o = Container.Default.Resolve<TestModel6>(new NonRegisteredModel("ARG"));
			Assert.IsNotNull(o, "Should not be null");
			Assert.IsNotNull(o.Single, "Should not be null");
			Assert.IsNotNull(o.Arg, "Should not be null");
			Assert.IsTrue(string.Compare(o.Arg.Name, "ARG") == 0, " Name should be ARG");
		}
	}
}
