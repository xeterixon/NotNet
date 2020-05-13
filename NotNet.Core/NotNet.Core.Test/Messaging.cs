using NUnit.Framework;
using NotNet.Core;
using System;

namespace NotNet.Core.Test
{
	class Subscriber: ISubscribe
	{
		public Subscriber() {
			this.Subscribe<string>("test", a =>
			{
				Assert.AreEqual(a, "payload");
			});
		}
		public void Dispose()
		{
			this.Unsubscribe("test");
		}
	}
	class Publisher : IPublish
	{
		public void  Send() {
			this.Publish<string>("test", "payload");
		}
	}
	[TestFixture]
	[Category("Messages")]
	public class Messages
	{
		[Test]
		public void Send1ToNobody()
		{
			var pub = new Publisher();
			pub.Send();
		}
		[Test]
		public void SendMessage() {

			var subscriber = new Subscriber();
			Message.Publish<string>("test", "payload");
			subscriber.Dispose();
		}
		[Test]
		public void UsePublisherClass() {
			var pub = new Publisher();
			var sub = new Subscriber();
			pub.Send();
		}
	}
}