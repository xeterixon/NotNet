using System;
using NotNet.Core;
using NotNet.Core.Forms;

namespace NNFTests
{
	[AutoRegister(ObjectDescription.Base)]
	public class ViewModelNoArgs : ViewModelBase
	{
		public Observable<string> Text { get; set; } = new Observable<string>(string.Empty);
		public ViewModelNoArgs()
		{
		}
	}
	[AutoRegister(ObjectDescription.Base)]
	public class ViewModelStringArg : ViewModelBase
	{
		public string Text { get; set; }
		public ViewModelStringArg(string arg)
		{
			Text = arg;
		}
	}

}
