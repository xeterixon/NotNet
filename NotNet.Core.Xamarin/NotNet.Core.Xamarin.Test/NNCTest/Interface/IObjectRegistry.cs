using System;
using System.Collections.Generic;

namespace NNCTest
{
	
	public interface IObjectRegistry
	{
		void SetInstance<T>(T instance);
		T GetInstance<T>();

	}
}
