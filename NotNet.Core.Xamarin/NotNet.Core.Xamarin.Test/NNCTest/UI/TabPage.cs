using System;

using Xamarin.Forms;
using NotNet.Core;
using NotNet.Core.Xamarin;
namespace NNCTest
{
	[AutoRegister(ObjectDescription.NoInterface)]
	public class TabPage : TabbedPage
	{
		~TabPage() 
		{
			System.Diagnostics.Debug.WriteLine("~TabPage()");
		}
		public TabPage() 
		{
			System.Diagnostics.Debug.WriteLine("TabPage default contructor");
		}
		// Prevent the default contstructor from been used by the IoC
		[PreferredConstructor]
		public TabPage(IContainer container)
		{
			Children.Add(container.Resolve<TestPage1>());	
			Children.Add(container.ResolveWrappedView<TestView1>());

		}
	}
}

