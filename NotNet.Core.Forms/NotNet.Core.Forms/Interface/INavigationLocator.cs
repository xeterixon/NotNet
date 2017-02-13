using System.Threading.Tasks;
using Xamarin.Forms;
namespace NotNet.Core.Forms
{
	public interface INavigationLocator
	{
		bool ShowNavigationBar { get; set; }
		bool ShowBackButton { get; set; }
		INavigation Navigation { get; }
		Task NavigateTo(string name);
		Task NavigateTo(string name, params object[] args);
		Task NavigateModalTo(string name);
		Task NavigateModalTo(string name, params object[] args);


		//NOTE VisualElement Should really be Page or View. Everyting else fails... 
		Task NavigateTo<T>() where T : VisualElement;
		Task NavigateModalTo<T>() where T : VisualElement;
		Task NavigateTo<T>(params object[] args) where T : VisualElement;
		Task NavigateModalTo<T>(params object[] args) where T : VisualElement;

	}
}
