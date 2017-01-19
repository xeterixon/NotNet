using System;
namespace NotNet.Core.Xamarin
{
	[System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class ViewModelAttribute : Attribute
	{
		public Type ViewModelType { get; private set; }
		public ViewModelAttribute(Type viewModelType)
		{
			ViewModelType = viewModelType;
		}
	}
}
