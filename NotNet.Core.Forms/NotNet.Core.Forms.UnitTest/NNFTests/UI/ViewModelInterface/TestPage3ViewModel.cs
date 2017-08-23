using System;
using NotNet.Core;
using NotNet.Core.Forms;

namespace NNFTests.UI.ViewModelInterface
{
	public interface ITestPage3ViewModel
	{
		string Text { get; set; }
	}
	[AutoRegister]
	public class TestPage3ViewModel : ViewModelBase, ITestPage3ViewModel
	{
		public string Text { get; set; } = "Hello from TestPage3ViewModel";
	}
}
