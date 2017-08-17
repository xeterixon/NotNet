using System;
using NotNet.Core;

namespace NNFTests
{
    public class TestSub : ISubscribe
    {
        private bool _unsub;
        public TestSub(bool unsubOnHandle)
        {
            _unsub = unsubOnHandle;
            this.Subscribe("empty", HandleTest);
            //Subscribing twice should not crash
            this.Subscribe("empty",HandleTest);
            if(unsubOnHandle)
                this.Subscribe<Payload>("payload",HandleAction);
        }

        void HandleAction(Payload obj)
        {
            System.Diagnostics.Debug.WriteLine(obj.Name);
        }

        void HandleTest()
        {
            if(_unsub)
            {
                this.Unsubscribe("empty");
            }
            System.Diagnostics.Debug.WriteLine("IN TEST");
        }
    }
}
