using System;
using System.Threading.Tasks;

namespace NotNet.Core.Forms
{
	public interface IPopupService
	{
#region Wrapped Page Tasks		
		Task ShowAlert(string title, string message, string buttonText);
		Task<bool> ShowAlert(string title, string message, string ok, string cancel);
		Task<string> ShowActionSheet(string title, string cancel, string delete, params string[] others);
#endregion

	}
}
