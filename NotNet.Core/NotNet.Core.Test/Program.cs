using System;
using NotNet.Core;
using NotNet.Core.Test.Model;

namespace NotNet.Core.Test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			RegisterStuff();
			var t1 = Container.Default.ResolveOrDefault<ITestModel1>();
			var t2 = Container.Default.ResolveOrDefault<ITestModel2>();
			var t3 = Container.Default.ResolveOrDefault<ITestModel3>();
			var t3_2 = Container.Default.ResolveOrDefault<ITestModel3>();
			var t4 = Container.Default.ResolveOrDefault<ITestModel4>();
			var t4_2 = (ITestModel4)Container.Default.GetService(typeof(ITestModel4));
			var t5 = Container.Default.ResolveOrDefault<TestModel5>();
			var t5_2 = Container.Default.ResolveOrDefault<TestModel5>();
			var t5_3 = (TestModel5)Container.Default.GetService(typeof(TestModel5));
			Console.WriteLine("T1   " + (t1?.Test1 ?? "null"));
			Console.WriteLine("T2   " + (t2?.Test1 ?? "null"));
			Console.WriteLine("T3_1 " + (t3?.Test1 ?? "null"));
			Console.WriteLine("T3_2 " + (t3_2?.Test1 ?? "null"));
			Console.WriteLine("T4   " + (t4?.Test1 ?? "null"));
			Console.WriteLine("T4_2 " + (t4_2?.Test1 ?? "null"));
			Console.WriteLine("T5_1 " + (t5?.Test1 ?? "null"));
			Console.WriteLine("T5_2 " + (t5_2?.Test1 ?? "null"));
			Console.WriteLine("T5_3 " + (t5_3?.Test1 ?? "null"));
		}
		private static void RegisterStuff() 
		{
			Container.Default.Register<TestModel5>();
			Container.Default.Register<ITestModel2,TestModel2>();
			Container.Default.AutoRegister(typeof(MainClass).Assembly);
		}
	}
}
