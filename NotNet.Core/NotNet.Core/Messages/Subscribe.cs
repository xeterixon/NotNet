using System;


namespace NotNet.Core
{
	/// <summary>
	/// Subscriber interface.
	/// Simply a tag interface to make the SubscribeExtensions hook up
	/// </summary>
	public interface ISubscribe { }
	public static class SubscribeExtensions
	{
		public static void Subscribe(this ISubscribe self, string channel, Action callback)
		{
			Subscriptions.Instance.AddSubscriber(channel, self, callback);
		}
		public static void Subscribe<T>(this ISubscribe self, string channel, Action<T> callback)
		{
			Subscriptions.Instance.AddSubscriber(channel, self, callback);
		}
		public static void Unsubscribe(this ISubscribe self, string channel)
		{
			Subscriptions.Instance.RemoveSubscriber(channel, self);
		}
	}
}

