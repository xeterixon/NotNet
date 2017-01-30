using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NotNet.Core;
using NotNet.Core.Xamarin;
using Xamarin.Forms;

namespace NNCTest
{
	public class TestView1ViewModel : ViewModelBase
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
		public ICommand PushMeCommand { get; private set; }
		bool _runTimer = true;
		bool TimerCallback()
		{
			SetProperty(Guid.NewGuid().ToString(), this, (t) => t.Test);
			SetProperty(Test, this, (m) => m.Title);
			return _runTimer;
		}

		public string Test { get; set; } = Guid.NewGuid().ToString();
		INavigationLocator navigation;
		IContainer container;
		TestModel2 _model2;
		public TestView1ViewModel(IContainer c, INavigationLocator nav, TestModel2 model2)
		{
			_model2 = model2;
			container = c;
			navigation = nav;
			Device.StartTimer(TimeSpan.FromSeconds(2),TimerCallback);
			PushMeCommand = new Command(async (obj) => { await PushStuff(); });
			Title = _model2.Test;
		}
		private async Task PushStuff() 
		{
			await navigation.PushAsync(container.ResolveWrappedView("TestView1",_model2));
		}
	}
}
