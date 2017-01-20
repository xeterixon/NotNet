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
		bool HandleFunc()
		{
			Test = Guid.NewGuid().ToString();
			OnPropertyChanged(nameof(Test));
			return _runTimer;
		}
		public override void OnPageAppearing()
		{
			Title = "Hello";
		}

		public string Test { get; set; } = Guid.NewGuid().ToString();
		INavigationLocator navigation;
		IContainer container;
		public TestView1ViewModel(IContainer c, INavigationLocator nav)
		{
			container = c;
			navigation = nav;
			Device.StartTimer(TimeSpan.FromSeconds(2),HandleFunc);
			PushMeCommand = new Command(async (obj) => { await PushStuff(); });
		}
		private async Task PushStuff() 
		{
			await navigation.PushAsync(container.ResolveWrappedView<TestView1>());
		}
	}
}
