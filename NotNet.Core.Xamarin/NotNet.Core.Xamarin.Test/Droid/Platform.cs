using System;
using NNCTest.Interface;

namespace NNCTest.Droid
{
	public class Platform : IPlatform
	{
		public Platform()
		{
			Name = "Droid";
		}
		public string Name { get; set; }
	}
}
