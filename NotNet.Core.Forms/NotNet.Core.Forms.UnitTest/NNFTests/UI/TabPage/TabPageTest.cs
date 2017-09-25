using System;
using NotNet.Core;
using NotNet.Core.Forms;
using Xamarin.Forms;

namespace NNFTests.UI.TabPage
{
    [AutoRegister]
    public class TabPageTest : TabbedPage, IPublish
    {
        bool SendMessage()
        {
			this.Publish("change", "TEXT_CHANGE");
            return false;
		}

        INavigationLocator _nav;
        ITimer _timer;
        public TabPageTest(ITimer timer ,INavigationLocator nav, TestPage1 page1, ModalPage page2)
        {
			_nav = nav;
            _timer = timer;
			page1.Title = "Tab1";
            page2.Title = "Tab2";
            Children.Add(page1);
            Children.Add(page2);
            _timer.StartTimer(TimeSpan.FromSeconds(1),ChangeTab);
            _timer.StartTimer(TimeSpan.FromSeconds(2),SendMessage);
        }

        bool ChangeTab()
        {
            _nav.ActivateTab("Tab2");
            return false;
        }
    }
}

