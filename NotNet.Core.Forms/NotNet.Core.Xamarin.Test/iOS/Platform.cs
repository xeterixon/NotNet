using System;
using NNCTest.Interface;

namespace NNCTest.iOS
{
	public class Platform : IPlatform
	{
		public Platform()
		{
			Name = "iOS";
		}
		public string Name { get; set; }
	}
}
