﻿using System;
using NotNet.Core.Test.Model;

namespace NotNet.Core.Test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			RegisterStuff();

			Console.WriteLine($"*** Registered types ***");
			foreach (var name in Container.Default.RegisteredNames) {
				Console.WriteLine($"* {name}");
			}
			Console.WriteLine($"************************");

			var t1 = Container.Default.ResolveOrDefault<ITestModel1>();
			var t2 = Container.Default.ResolveOrDefault<ITestModel2>();
			var t3 = Container.Default.ResolveOrDefault<ITestModel3>();
			var t3_2 = Container.Default.ResolveOrDefault<ITestModel3>();
			var t4 = Container.Default.ResolveOrDefault<ITestModel4>();
			var t4_2 = (ITestModel4)Container.Default.GetService(typeof(ITestModel4));
			var t5 = Container.Default.ResolveOrDefault<TestModel5>();
			var t5_2 = Container.Default.ResolveOrDefault<TestModel5>();
			var t5_3 = (TestModel5)Container.Default.GetService(typeof(TestModel5));
			var t6 = Container.Default.ResolveOrDefault<TestModel6>();
			var t7 = Container.Default.Resolve<TestModel7>(new TestArg1(), new TestArg3());
			//t8 should be null-ish, but not throw...
			var t8 = Container.Default.ResolveOrDefault<object>(null, null);
			var t9 = (TestModel6)Container.Default.Resolve("TestModel6");
			var t10 = Container.Default.ResolveAll<ITestModel89>();

			Console.WriteLine("T1   " + (t1?.Test1 ?? "null"));
			Console.WriteLine("T2   " + (t2?.Test1 ?? "null"));
			Console.WriteLine("T3_1 " + (t3?.Test1 ?? "null"));
			Console.WriteLine("T3_2 " + (t3_2?.Test1 ?? "null"));
			Console.WriteLine("T4   " + (t4?.Test1 ?? "null"));
			Console.WriteLine("T4_2 " + (t4_2?.Test1 ?? "null"));
			Console.WriteLine("T5_1 " + (t5?.Test1 ?? "null"));
			Console.WriteLine("T5_2 " + (t5_2?.Test1 ?? "null"));
			Console.WriteLine("T5_3 " + (t5_3?.Test1 ?? "null"));
			Console.WriteLine("T6   " + (t6?.Test ?? "null"));
			Console.WriteLine("T7   " + (t7?.Test ?? "null"));
			Console.WriteLine("T8   " + (t8 == null ?  "null, as it should" : "Not null, WTF"));
			Console.WriteLine("T9   " + (t9?.Test) ?? "null");
			foreach (var item in t10) 
			{
				Console.WriteLine(item.Name);
			}
		}
		private static void RegisterStuff() 
		{
			
			Container.Default.AutoRegister(typeof(MainClass).Assembly);
			Container.Default.Register<TestModel5>();
			Container.Default.Register<TestModel7>();
			Container.Default.Register<ITestModel2,TestModel2>();
			Container.Default.Register<ITestModel89, TestModel8>();
			Container.Default.Register<ITestModel89, TestModel9>();
		}
	}
}
