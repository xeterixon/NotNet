using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace NNFTests.UITest
{
	[TestFixture(Platform.iOS)]
	//[TestFixture(Platform.Android)]
	public class NavigationTests
	{
		IApp app;
		Platform platform;
		readonly string ButtonId1 = "Button1";

		readonly string ButtonId2 = "Button2";
		readonly string ButtonId3 = "Button3";
		readonly string ButtonId4 = "Button4";
		readonly string LabelId = "LabelId";
		readonly string ExpectedLabelText = "Some Random Text";
		public NavigationTests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
//			app.Repl();
		}
		private void PushView(string buttonId, string waitForAfterTap) 
		{
			app.WaitForElement((arg) => arg.Marked(buttonId)); ;
			app.Tap(c => c.Marked(buttonId));
			app.WaitForElement(c => c.Marked(waitForAfterTap));
			
		}
		[Test]
		public void NavigateToWrappedViewAndBack()
		{
			Console.WriteLine("Basic navigation");
			
			PushView(ButtonId1,LabelId);
			var label = app.Query(c => c.Marked(LabelId)).First();
			Assert.IsTrue(label.Text == ExpectedLabelText, $"Text should be {ExpectedLabelText}. Was {label.Text}");
			if (platform == Platform.iOS)
			{
				app.Tap(c => c.Marked("Back"));
			}
			else
			{
				app.Back();
			}
			
			PushView(ButtonId2, LabelId);
			var labelText = app.Query(c => c.Marked(LabelId)).First().Text;
			Assert.IsTrue(labelText == ExpectedLabelText, $"Text should be {ExpectedLabelText}. Was {labelText}");
			app.Tap(c => c.Marked("PopPageButton"));
			PushView(ButtonId3, LabelId);
			var anyBack = app.Query((arg) => arg.Marked("Back")).Any();
			Assert.IsFalse(anyBack, "There should be no back button");
			app.Tap(c => c.Marked("PopPageButton"));
			Console.WriteLine("Test modal");

			PushView(ButtonId4,"PopModal");
			app.Tap(c => c.Marked("PopModal"));

			PushView("Button5", "PopModal");
			Console.WriteLine("Test action sheet");
			app.Tap(c => c.Marked("PopModal"));
			app.Tap(i => i.Marked("Button3")); ;
			app.Tap(i => i.Text("Show sheet"));
			app.Tap(i => i.Marked("Cancel"));
			app.Tap(i => i.Marked("OK"));
			app.Tap((arg) => arg.Marked("PopPageButton"));

			Console.WriteLine("Testing new nav stack");
			PushView("Button6", "PushPage");
			app.Tap(c => c.Marked("PushPage"));
			app.WaitForElement((arg) => arg.Marked("PushPage"));
			app.Tap(c => c.Marked("PushPage"));
			app.WaitForElement((arg) => arg.Marked("PushPage"));
			app.Tap(c => c.Marked("PushPage"));
			app.WaitForElement((arg) => arg.Marked("PushPage"));
			app.Tap((arg) => arg.Marked("ShowSheet"));
			app.Tap(i => i.Marked("Cancel"));
			app.Tap(i => i.Marked("OK"));

			app.Tap(c => c.Marked("PopToRoot"));
			app.WaitForElement((arg) => arg.Marked("PopMe"));
			app.Tap(c => c.Marked("PopMe"));
		}
	}		
}
