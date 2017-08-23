using Xamarin.Forms;

namespace NotNet.Core.Forms
{
	public interface IApplicationDelegate
	{
		Application App { get; }
		Page CurrentPage { get; }
		INavigation Navigation { get; }
	}
}
