using Xamarin.Forms;
using System.Collections.Generic;
namespace NotNet.Core.Forms
{
	public static class CleanableExtension
	{
		public static void Cleanup(this Page self)
		{
			CleanPage(self);
			//Do we need to handle other special pages?
			if (self is TabbedPage tp)
			{
				CleanTabPage(tp);
			}
			if (self is NavigationPage np)
			{
				CleanPage(np.CurrentPage);
			}
			if (self is MasterDetailPage mp)
			{
				CleanPage(mp.Master);
				CleanPage(mp.Detail);
			}
		}
		static void CleanPage(Page p)
		{
			CleanBindableObject(p);
			CleanBindableObject((p as ContentPage)?.Content);

		}
		public static void Cleanup(this View self)
		{
			CleanBindableObject(self);
		}
		static void CleanTabPage(TabbedPage page)
		{

			foreach (var p in page?.Children ?? new List<Page>())
			{
				CleanPage(p);
			}
		}
		static void CleanBindableObject(BindableObject bindable)
		{

			(bindable?.BindingContext as ICleanup)?.Cleanup();
			(bindable as ICleanup)?.Cleanup();
		}
	}
}
