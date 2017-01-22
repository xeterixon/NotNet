using System;
using NNCTest.Interface;
using NotNet.Core;
using NotNet.Core.Xamarin;

namespace NNCTest
{
	public interface ITestPage1ViewModel : IViewModelBase
	{
		string Test { get; set; }
		string Platform { get; set; }
	}
	public class TestPage1ViewModel : ViewModelBase, ITestPage1ViewModel
	{
		~TestPage1ViewModel() 
		{
			System.Diagnostics.Debug.WriteLine("~TestPage1ViewModel()");
			
		}
		public string Test1 { get { return _registry.GetInstance<TestModel1>().Test; }}
		public string Platform { get; set; }
		IObjectRegistry _registry;
		public TestPage1ViewModel(TestModel1 data, IContainer container,INavigationLocator nav, IObjectRegistry reg)
		{
			_registry = reg;
			Platform = container.Resolve<IPlatform>().Name;
 			Test = data.Test;
		}
		public string Test { get; set; }
	}
}
