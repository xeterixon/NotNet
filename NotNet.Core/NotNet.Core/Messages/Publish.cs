
using System.Threading.Tasks;

namespace NotNet.Core
{
	public interface IPublish { }
	public static class PublishExtensions
	{
		public static void Publish(this IPublish self, string channel)
		{
			Publish(self, channel, (object)null);
		}
		public static void Publish<T>(this IPublish self, string channel, T payload)
		{
			Subscriptions.Instance.Publish(channel, payload);
		}
		public static async Task PublishAsync(this IPublish self, string channel)
		{
			await PublishAsync(self, channel, (object)null);
		}
		public static async Task PublishAsync<T>(this IPublish self, string channel, T payload)
		{
			await Task.Run(() => Subscriptions.Instance.Publish(channel, payload));
		}
	}
}

