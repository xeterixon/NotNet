using System;
using System.Collections.Generic;
using System.Linq;
namespace NotNet.Core
{
	internal class SubscriptionEntry
	{
		public ISubscribe Subscriber;
		public Action<object> Callback;
		public string Channel;
	};

	internal sealed class Subscriptions
	{
		private Dictionary<string, List<SubscriptionEntry>> _database;
		private static Subscriptions _instance = new Subscriptions();
		public static Subscriptions Instance => _instance;
		readonly object gate = new object();

		private Subscriptions()
		{
			_database = new Dictionary<string, List<SubscriptionEntry>>();
		}

		internal void Publish<T>(string channel, T payload)
		{
			if (!_database.ContainsKey(channel)) return;
			var sublist = _database.FirstOrDefault(x => x.Key == channel).Value;
			//NOTE ToArray makes it possible for the subscriber 
			// to unsubscribes during callback
			foreach(var sub in sublist.ToArray())
			{
				sub.Callback?.Invoke(payload);
			}
		}

		internal void RemoveSubscriber(string channel, ISubscribe subscriber)
		{
			var sub = _database.FirstOrDefault(x => x.Key == channel).Value.FirstOrDefault(s => object.ReferenceEquals(s.Subscriber, subscriber));
			if(sub != null)
			{
				lock(gate)
				{
					_database[channel].Remove(sub);
				}
			}
		}

		internal void AddSubscriber(string channel, ISubscribe subscriber, Action action)
		{
			AddSubscriber(channel, subscriber, new Action<object>((_) => action()));
		}

		internal void AddSubscriber<T>(string channel, ISubscribe subscriber, Action<T> action)
		{
			lock(gate)
			{
				List<SubscriptionEntry> sublist;
				if(!_database.ContainsKey(channel))
				{
					sublist = new List<SubscriptionEntry>();
					_database.Add(channel, sublist);
				}
				sublist = _database.FirstOrDefault(x => x.Key == channel).Value;
				if (!sublist.Any(s => object.ReferenceEquals(s.Subscriber, subscriber)))
				{
					sublist.Add(new SubscriptionEntry
					{
						Subscriber = subscriber,
						Callback = new Action<object>((obj) => action((T)obj)),
						Channel = channel
					});
				}
			}
		}
	}
}

