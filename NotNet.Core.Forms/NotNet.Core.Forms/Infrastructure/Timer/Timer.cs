using System;
using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public class Timer : ITimer
	{
		public void StartTimer(TimeSpan interval, Func<bool> callback)
		{
			Device.StartTimer(interval, callback);
		}
	}
}
