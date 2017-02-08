using System;
using NNCTest.Interface;
using NotNet.Core;
using NotNet.Core.Forms;


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
		public string Test1 {
			get {
				return "CRAP";
			}
		}
		public string Platform { get; set; }
		public TestPage1ViewModel(TestModel1 data, IContainer container,INavigationLocator nav)
		{

			Platform = container.Resolve<IPlatform>().Name;
 			Test = data.Test;
			Title = "Title from TestPage1ViewModel";
		}
		public string Test { get; set; }
	}
}
