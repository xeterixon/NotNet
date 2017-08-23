using System.Threading.Tasks;
using Xamarin.Forms;
namespace NotNet.Core.Forms
{
	public interface INavigationLocator
	{
		/// <summary>
		/// Flag that indicates if the navigation bar should be visible when pushing the next page
		/// Note that this is not per page, but rather for any subsequent pages.
		/// Use the HideNavigationBar class to scoop it.
		/// </summary>
		/// <value><c>true</c> if show navigation bar; otherwise, <c>false</c>.</value>
		bool ShowNavigationBar { get; set; }
		/// <summary>
		/// Flag that indicates if the back button should be visible when pushing the next page
		/// Note that this is not per page, but rather for any subsequent pages.
		/// Use the HideBackbuttonClase class to scoop it.
		/// </summary>
		/// <value><c>true</c> if show navigation bar; otherwise, <c>false</c>.</value>

		bool ShowBackButton { get; set; }
		/// <summary>
		/// The current navigation instance.
		/// </summary>
		/// <value>The navigation.</value>
		INavigation Navigation { get; }
		Task NavigateTo(string name);
		Task NavigateTo(string name, params object[] args);
		Task NavigateModalTo(string name);
		Task NavigateModalTo(string name, params object[] args);
		/// <summary>
		/// Activates the tab if the current page is a TabbedPage and the
		/// tab exists as a child
		/// </summary>
		/// <param name="tabTitle">The title of the tab </param>
		Task ActivateTab(string tabTitle);
		/// <summary>
		/// If the current page is a MasterDetailPage, this will open or close the master
		/// </summary>
		/// <value><c>true</c> if master visible; otherwise, <c>false</c>.</value>
		bool MasterVisible { set; get; }

		//NOTE VisualElement Should really be Page or View. Everyting else fails... 
		Task NavigateTo<T>() where T : VisualElement;
		Task NavigateModalTo<T>() where T : VisualElement;
		Task NavigateTo<T>(params object[] args) where T : VisualElement;
		Task NavigateModalTo<T>(params object[] args) where T : VisualElement;

	}
}
