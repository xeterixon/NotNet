using System.Threading.Tasks;

namespace NotNet.Core.Forms
{
	public class PopupService : IPopupService
	{
		readonly IApplicationDelegate _app;
		public PopupService(IApplicationDelegate appDelegate)
		{
			_app = appDelegate;
		}

		public Task ShowAlert(string title, string message, string buttonText)
		{
			return _app.CurrentPage.DisplayAlert(title, message, buttonText);
		}
		public Task<bool> ShowAlert(string title, string message, string ok, string cancel)
		{
			return _app.CurrentPage.DisplayAlert(title, message, ok, cancel);
		}
		public Task<string> ShowActionSheet(string title, string cancel, string delete, params string[] others)
		{
			return _app.CurrentPage.DisplayActionSheet(title, cancel, delete, others);
		}


	}
}
