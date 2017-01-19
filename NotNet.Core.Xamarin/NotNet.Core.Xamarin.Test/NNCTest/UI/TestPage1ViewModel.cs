using System;
using NotNet.Core.Xamarin;

namespace NNCTest
{
	public interface ITestPage1ViewModel 
	{
		string Test { get; set; }
	}
	public class TestPage1ViewModel : Observable, ITestPage1ViewModel
	{
		~TestPage1ViewModel() 
		{
			System.Diagnostics.Debug.WriteLine("~TestPage1ViewModel()");
			
		}

		public TestPage1ViewModel(TestModel1 data)
		{
			Test = data.Test;
		}
		public string Test { get; set; }
	}
}
