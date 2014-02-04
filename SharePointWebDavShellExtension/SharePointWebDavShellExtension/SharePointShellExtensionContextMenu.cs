using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using SharePointWebDavShellExtension.Properties;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using Path = SharePointWebDavShellExtension.Helpers.Path;

namespace SharePointWebDavShellExtension
{
	[ComVisible(true)]
	[COMServerAssociation(AssociationType.AllFiles)]
	public class SharePointShellExtensionContextMenu : SharpContextMenu
	{
		internal const string WebDavRootFolder = "DavWWWRoot";

		private readonly IKernel _subMenuKernel;

		public SharePointShellExtensionContextMenu()
		{
			_subMenuKernel = new StandardKernel(new SubMenuModule());
		}

		protected override bool CanShowMenu()
		{
			bool canShow = false;
			var itemPaths = this.SelectedItemPaths;
			if (itemPaths != null && itemPaths.Any())
			{
				string uncFolderPath = Path.GetUNCPath(itemPaths.First());
				foreach (var selectedItemPath in itemPaths)
				{
					canShow = Path.IsNetworkPath(selectedItemPath) && uncFolderPath.Contains(WebDavRootFolder);
					if (!canShow)
						break;
				}
			}
			return canShow;
		}

		protected override ContextMenuStrip CreateMenu()
		{
			//  Create the menu strip.
			var menu = new ContextMenuStrip();

			var rootItem = new ToolStripMenuItem
			{
				Text = Resources.SharePointShellExtension_Title,
				Image = Resources.SP_Logo
			};
			menu.Items.Add(rootItem);

			// TODO: ohne new SharePointToolStripItem(toolStripItemsSetting) sondern einfach nur rootITem.DropDownItems.Add(item)
			var toolStripItemsSettings = _subMenuKernel.GetAll<ISharePointToolStripItemSettings>();
			foreach (var toolStripItemsSetting in toolStripItemsSettings)
				rootItem.DropDownItems.Add(new SharePointToolStripItem(toolStripItemsSetting) { SelectedItemPaths = this.SelectedItemPaths.Select(Path.GetUNCPath) });


			return menu;
		}
	}
}
