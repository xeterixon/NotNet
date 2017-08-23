using System;
using System.Threading.Tasks;

namespace NotNet.Core
{
	/// <summary>
	/// Publish a message
	/// </summary>
	public static class Message
	{
		public static void Publish(string channel)
		{
			Subscriptions.Instance.Publish(channel, (object)null);
		}
		public static void Publish<T>(string channel, T payload)
		{
			Subscriptions.Instance.Publish(channel, payload);
		}
		public static async Task PublishAsync( string channel)
		{
			await PublishAsync(channel, (object)null);
		}
		public static async Task PublishAsync<T>(string channel, T payload)
		{
			await Task.Run(() => Subscriptions.Instance.Publish(channel, payload));
		}

	}
}
