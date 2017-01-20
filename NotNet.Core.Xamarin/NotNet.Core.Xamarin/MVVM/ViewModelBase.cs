using System;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public abstract class ViewModelBase : Observable
	{
		public INavigation Navigation { get; set; }
	}
}
