using System.Linq;
using NUnit.Framework;

namespace NotNet.Core.UnitTest
{
	[TestFixture]
	[Category("Service location tests")]
	public class ServiceLocation
	{
		[Test]
		public void Resolve1()
		{
			var m1 = Container.Default.Resolve<ITestModel1>();
			Assert.NotNull(m1, "Should not be null");
		}
		[Test]
		public void SingletonTest()
		{
			var m1 = Container.Default.Resolve<SingletonModel1>();
			var m2 = Container.Default.Resolve<SingletonModel1>();

			Assert.AreEqual(m1, m2, "Instances should be the same");
			Assert.AreEqual(m1.Id, m2.Id, "Id should be the same");

		}
		[Test]
		public void TryResolveShouldNotThrowForUnregisteredType()
		{
			var o = Container.Default.ResolveOrDefault<object>();
			Assert.IsNull(o, "Should be null");
		}
		[Test]
		public void ResolveAutoRegisteredInterface()
		{
			var o = Container.Default.Resolve<IAutoRegisteredModel2>();
			Assert.IsNotNull(o, "Should not be null");
			Assert.IsTrue(string.Compare(o.Name, nameof(AutoRegisteredModel2)) == 0, "Name should be same as class name");
		}

		[Test]
		public void ResolveAutoRegisteredClass()
		{
			var o = Container.Default.Resolve<AutoRegisteredModel1>();
			Assert.IsNotNull(o, "Should not be null");
			Assert.IsTrue(string.Compare(o.Name, nameof(AutoRegisteredModel1)) == 0, "Name should be same as class name");
		}
		[Test]
		public void ResolveMultiple() 
		{
			var o = Container.Default.ResolveAll<IMulti>();
			Assert.IsTrue(o.Any(), "Should have some implementation");
			Assert.IsTrue(o.Count() > 1, "Should be more than 1");
			Assert.AreNotSame(o.First(), o.Last(), "Should be different instances");
		}
		[Test]
		public void ResolvePreveredConsturctor() 
		{
			var o = Container.Default.Resolve<ITestModel7>();
			Assert.NotNull(o, "Should not be null");
			Assert.IsNotEmpty(o.Name, "Name should not be empty");
			Assert.NotNull(o.Model, "Model should no be null");
		}
		[Test]
		public void RemoveRegisterdItem() 
		{
			Container.Default.RegisterTransient<TemporaryModel>();
			var obj = Container.Default.Resolve<TemporaryModel>();
			Assert.NotNull(obj, "Should not be null");
			Container.Default.Unregister<TemporaryModel>();

			obj = Container.Default.ResolveOrDefault<TemporaryModel>();
			Assert.Null(obj, "Generic - Should be null");
			Container.Default.RegisterTransient<TemporaryModel>();

			obj = Container.Default.Resolve<TemporaryModel>();
			Assert.NotNull(obj, "Should not be null");
			Container.Default.Unregister(typeof(TemporaryModel));
			obj = Container.Default.ResolveOrDefault<TemporaryModel>();
			Assert.Null(obj, "Type - Should be null");

		}
	}
}
