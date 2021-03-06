namespace NotNet.Core.Forms
{
	/// <summary>
	/// View model base.
	/// Should be used as a BindingContext for a Page or a View
	/// </summary>
	public abstract class ViewModelBase : Observable, IViewModelBase, ICleanup
	{
		string _title = string.Empty;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				SetProperty(ref _title, value);
			}
		}
		protected ViewModelBase() { }
		/// <summary>
		/// Override to do cleanup.
		/// This is the place to unhook events and other things that might prevent the
		/// garbage collector from doing it's job.
		/// It will be called only once,  when a page holding the view model is popped, hopefully...
		/// </summary>
		public virtual void Cleanup() { }
		public virtual void OnPageAppearing() { }
		public virtual void OnPageDisappearing() { }
		public virtual void OnInitialPageAppearing() { }
		public virtual bool OnBackButtonPressed()
		{
			return false;
		}

	}
}
