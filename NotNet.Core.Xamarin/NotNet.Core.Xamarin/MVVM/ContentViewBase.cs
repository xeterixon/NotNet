using System;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public class ContentViewBase : ContentView
	{
		protected override void OnParentSet()
		{
			base.OnParentSet();
			if (Parent == null) return;

		}
	}
}
