using System;
using NotNet.Core;

namespace NNFTests
{
    public class TestPub : IPublish
    {
        public TestPub()
        {
        }
        public void Send(string channel)
        {
            this.Publish(channel);
        }
		public void Send(string channel, Payload p)
		{
			this.Publish(channel,p);
		}
	}
}
