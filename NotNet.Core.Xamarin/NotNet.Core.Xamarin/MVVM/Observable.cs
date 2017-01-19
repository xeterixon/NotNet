using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotNet.Core.Xamarin
{
	public class Observable : INotifyPropertyChanged, ICleanable
	{
		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		public virtual void Cleanup(){}

		virtual protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			if (name == null)
				return;
			var handler = PropertyChanged;
			if (handler == null)
				return;
			handler(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}

	public class Observable<T> : Observable
	{
		private T _Value;
		public T Value
		{
			get { return _Value; }
			set
			{
				_Value = value;
				OnPropertyChanged();
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
