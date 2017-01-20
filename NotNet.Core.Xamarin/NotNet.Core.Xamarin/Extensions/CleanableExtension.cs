using System;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public static class CleanableExtension
	{
		public static void Cleanup(this Page self) 
		{
			CleanBindableObject(self);
		}
		public static void Cleanup(this View self) 
		{
			CleanBindableObject(self);
		}
		private static void CleanBindableObject(BindableObject bindable) 
		{
			(bindable?.BindingContext as ICleanable)?.Cleanup();
			(bindable as ICleanable)?.Cleanup();
		}
	}
}
