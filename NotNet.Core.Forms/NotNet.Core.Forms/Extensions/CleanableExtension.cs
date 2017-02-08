using Xamarin.Forms;
using System.Collections.Generic;
namespace NotNet.Core.Forms
{
	public static class CleanableExtension
	{
		public static void Cleanup(this Page self) 
		{
			//Do we need to handle other special pages?
			if (self is TabbedPage)
			{
				CleanTabPage(self as TabbedPage);
			}
			else {
				CleanPage(self);
			}
		}
		private static void CleanPage(Page p) 
		{
			CleanBindableObject(p);
			CleanBindableObject((p as ContentPage)?.Content);
			
		}
		public static void Cleanup(this View self) 
		{
			CleanBindableObject(self);
		}
		private static void CleanTabPage(TabbedPage page) 
		{
			
			foreach (var p in page?.Children ?? new List<Page>()) 
			{
				CleanPage(p);
			}
		}
		private static void CleanBindableObject(BindableObject bindable) 
		{
			
			(bindable?.BindingContext as ICleanup)?.Cleanup();
			(bindable as ICleanup)?.Cleanup();
		}
	}
}
