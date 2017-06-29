using System;
using NotNet.Core;

namespace NNFTests.Model
{
    public interface ISingletonModel
    {
        Guid Id { get; }
    }
    [AutoRegister(ObjectLifecycle.Singleton)]
    public class SingletonModel : ISingletonModel
    {
        public Guid Id { get; private set; }
        public SingletonModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
