using System;
using System.Drawing;

namespace SharePointWebDavShellExtension
{
	public interface ISharePointToolStripItemSettings
	{
		string Text { get; }
		Image Image { get; }
		EventHandler Click { get; }
	}
}