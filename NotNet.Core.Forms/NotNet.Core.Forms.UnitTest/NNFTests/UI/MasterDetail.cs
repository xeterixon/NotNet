using System;
using NotNet.Core;
using Xamarin.Forms;
using NotNet.Core.Forms;
namespace NNFTests
{
	[AutoRegister(ObjectDescription.Base)]
	public class MasterDetail : MasterDetailPage
	{
#pragma warning disable
		readonly INavigationLocator _navigation;
#pragma warning restore
		public MasterDetail(INavigationLocator nav, IContainer container)
		{
			_navigation = nav;
			Master = container.Resolve<TestPage1>();
			Detail = container.Resolve<ModalPage>();
		}
	}
}

