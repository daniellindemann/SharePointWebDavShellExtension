using System;
using System.Drawing;
using System.Windows.Forms;
using SharePointWebDavShellExtension.Helpers;

namespace SharePointWebDavShellExtension
{
	public class DiscardCheckoutToolStripSettings : ISharePointToolStripItemSettings
	{
		public string Text
		{
			get { return Properties.Resources.Action_Text_DiscardCheckOut; }
		}

		public Image Image
		{
			get { return Properties.Resources.Icon_DiscardCheckOut; }
		}

		public EventHandler Click
		{
			get
			{
				return (sender, args) =>
				{
					var selectedItems = (sender as SharePointToolStripItem).SelectedItemPaths;
					foreach (string selectedItem in selectedItems)
					{
						try
						{
							SharePoint.WithFile(selectedItem, (ctx, file) =>
							{
								file.UndoCheckOut();
								ctx.ExecuteQuery();
							});
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				};
			}
		}
	}
}