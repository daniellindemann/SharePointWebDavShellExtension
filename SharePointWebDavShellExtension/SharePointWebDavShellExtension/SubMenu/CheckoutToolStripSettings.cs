using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SharePointWebDavShellExtension.Helpers;
using Resources = SharePointWebDavShellExtension.Properties.Resources;

namespace SharePointWebDavShellExtension
{
	public class CheckoutToolStripSettings : ISharePointToolStripItemSettings
	{
		public string Text
		{
			get { return Properties.Resources.Action_Text_CheckOut; }
		}

		public Image Image
		{
			get { return Properties.Resources.Icon_CheckOut; }
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
								file.CheckOut();
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