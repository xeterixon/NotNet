using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System;
using System.Reflection;
namespace NotNet.Core.Forms
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
		protected void SetProperty<TVal, TTarget>(TVal input, TTarget target, Expression<Func<TTarget, TVal>> outExpr) 
		{
	        var expr = (MemberExpression)outExpr.Body;
			var prop = (PropertyInfo)expr.Member;
			var apa = (TVal)prop.GetValue(target);
			if (object.Equals(apa, input)) return;
			prop.SetValue(target, input, null);
		}
		protected void SetProperty<T>(ref T self, T value, [CallerMemberName] string propertyName = null) 
		{
			if (object.Equals(self, value)) return;
			self = value;
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