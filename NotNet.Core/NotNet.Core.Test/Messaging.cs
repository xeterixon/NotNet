using NUnit.Framework;
using NotNet.Core;
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
		public void SendMessage() {

			var subscriber = new Subscriber();
			Message.Publish<string>("test", "payload");
		}
		[Test]
		public void UsePublisherClass() {
			var pub = new Publisher();
			var sub = new Subscriber();
			pub.Send();
		}
	}

}