using System;
using NotNet.Core;

namespace NNFTests
{
    public class Payload
    {
        public string Name { get; set; }
    }
    public class PubSubTest
    {
        TestPub _pub = new TestPub();
        TestSub _sub1 = new TestSub(false);
        TestSub _sub2 = new TestSub(true);
		public void SendToTest()
        {
            _pub.Send("empty");
            _pub.Send("payload", new Payload{Name = "Payload"});
			Message.Publish("empty");
        }
    }
}
