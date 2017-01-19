using System;
using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NNCTest
{
	public class TestView1ViewModel : Observable
	{
		~TestView1ViewModel() 
		{
			System.Diagnostics.Debug.WriteLine("~TestView1ViewModel()");
		}
		public override void Cleanup()
		{
			base.Cleanup();
			_runTimer = false;
		}
		bool _runTimer = true;
		bool HandleFunc()
		{
			Test = Guid.NewGuid().ToString();
			OnPropertyChanged(nameof(Test));
			return _runTimer;
		}

		public string Test { get; set; } = Guid.NewGuid().ToString();
		public TestView1ViewModel()
		{
			Device.StartTimer(TimeSpan.FromSeconds(2),HandleFunc);
		}
	}
}
