using System;
using Xamarin.Forms;

namespace NotNet.Core.Xamarin
{
	public abstract class ViewModelBase : Observable, IViewModelBase, ICleanable
	{
		string _title = string.Empty;
		public string Title {
			get {
				return _title;
			}
			set {
				_title = value;
				OnPropertyChanged();
			}
		}
		protected ViewModelBase() { }
		/// <summary>
		/// Override to do cleanup. Should be called when a page holding the view is popped
		/// </summary>
		public virtual void Cleanup() { }
		public virtual void OnPageAppearing(){}
		public virtual void OnPageDisappearing(){}
	}
}
