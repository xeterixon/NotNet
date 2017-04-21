using System;
namespace NotNet.Core.Forms
{
	public interface ITimer
	{
		void StartTimer(TimeSpan interval, Func<bool> callback);
	}
}
