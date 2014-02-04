using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SharePointWebDavShellExtension.Helpers;

namespace SharePointWebDavShellExtension
{
	public class PublishToolStripSettings : ISharePointToolStripItemSettings
	{
		public string Text
		{
			get { return Properties.Resources.Action_Text_Publish; }
		}

		public Image Image
		{
			get { return Properties.Resources.Icon_Publish; }
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
								file.Publish("shell publish");
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