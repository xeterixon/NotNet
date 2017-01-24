using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotNet.Core.Xamarin
{
	public class Observable : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		virtual protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			if (name == null)
				return;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
		protected void SetProperty<T>(ref T self, T value, [CallerMemberName] string propertyName = null) 
		{
			if (object.Equals(self, value)) return;
			OnPropertyChanged(propertyName);
		}
	}

	public class Observable<T> : Observable
	{
		private T _Value;
		public T Value
		{
			get { return _Value; }
			set
			{
				SetProperty(ref _Value, value);
			}
		}
		public Observable()
		{

		}
		public Observable(T v)
		{
			Value = v;
		}

		public static implicit operator T(Observable<T> v)
		{
			return v.Value;
		}

	}
}
