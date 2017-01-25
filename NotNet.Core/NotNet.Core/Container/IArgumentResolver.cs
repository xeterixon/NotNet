using System;
namespace NotNet.Core
{
	public interface IArgumentResolver
	{
		T Resolve<T>(params object[] args);
	}
}
