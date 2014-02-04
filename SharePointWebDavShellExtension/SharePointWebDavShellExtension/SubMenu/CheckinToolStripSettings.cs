using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SharePointWebDavShellExtension.Helpers;
using SharePointWebDavShellExtension.Properties;

namespace SharePointWebDavShellExtension
{
	public class CheckinToolStripSettings : ISharePointToolStripItemSettings
	{
		public string Text
		{
			get { return Properties.Resources.Action_Text_CheckIn; }
		}

		public Image Image
		{
			get { return Properties.Resources.Icon_CheckIn; }
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
								file.CheckIn("shell checkin", CheckinType.MinorCheckIn);
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