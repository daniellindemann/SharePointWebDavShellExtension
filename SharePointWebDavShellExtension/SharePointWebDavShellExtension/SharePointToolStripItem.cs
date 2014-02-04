using System.Collections.Generic;
using System.Windows.Forms;
using Ninject;

namespace SharePointWebDavShellExtension
{
	public class SharePointToolStripItem : ToolStripMenuItem
	{
		[Inject]
		public SharePointToolStripItem(ISharePointToolStripItemSettings settings)
			: base()
		{
			Text = settings.Text ?? string.Empty;
			Image = settings.Image;
			if (settings.Click != null)
				Click += settings.Click;
		}

		public IEnumerable<string> SelectedItemPaths { get; set; }
	}
}