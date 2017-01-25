using System.Threading.Tasks;
using Xamarin.Forms;
namespace NotNet.Core.Xamarin
{
	public interface INavigationLocator
	{
		INavigation Navigation { get; }
		Task NavigateToView<T>() where T : View;
		Task NavigateModalToView<T>() where T : View;
		Task NavigateTo<T>() where T : Page;
		Task NavigateModalTo<T>() where T : Page;

		Task NavigateToView<T>(params object[] args) where T : View;
		Task NavigateModalToView<T>(params object[] args) where T : View;

		Task NavigateTo<T>(params object[] args) where T : Page;
		Task NavigateModalTo<T>(params object[] args) where T : Page;

	}
}
