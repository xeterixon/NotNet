using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public static class NavigationLocatorExtensions
	{
		public static void InsertPageBefore(this INavigationLocator self, Page page, Page before)
		{
			self.Navigation.InsertPageBefore(page, before);
		}

		public static Task<Page> PopAsync(this INavigationLocator self, bool animated= true) 
		{
			return self.Navigation.PopAsync(animated);
		}

		public static Task<Page> PopModalAsync(this INavigationLocator self,bool animated = true)
		{
			return self.Navigation.PopModalAsync(animated);
		}

		public static Task PopToRootAsync(this INavigationLocator self,bool animated= true)
		{
			return self.Navigation.PopToRootAsync(animated);
		}

		public static Task PushAsync(this INavigationLocator self,Page page, bool animated = true)
		{
			return self.Navigation.PushAsync(page, animated);
		}

		public static Task PushModalAsync(this INavigationLocator self,Page page, bool animated = true)
		{
			return self.Navigation.PushModalAsync(page, animated);
		}

		public static void RemovePage(this INavigationLocator self,Page page)
		{
			self.Navigation.RemovePage(page);
		}
	}
}
