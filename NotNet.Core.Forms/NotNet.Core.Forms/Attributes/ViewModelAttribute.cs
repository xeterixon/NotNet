using System;
namespace NotNet.Core.Forms
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
