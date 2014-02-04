using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SharePointWebDavShellExtension.Helpers
{
	public static class SharePoint
	{
		public static void WithFile(string url, Action<ClientContext, File> fileHandler)
		{
			var fullUrl = Path.ConvertToUrl(url, false);
			var serverRelativeUrl = Path.ConvertToUrl(url, true);
			var webUrl = fullUrl.Substring(0, fullUrl.LastIndexOf('/'));

			LoopHelper.TryWhile(() => webUrl.Replace("http://", string.Empty).Count(c => c == '/') > 0,
			() =>
			{
				bool done = false;
				try
				{
					var ctx = new ClientContext(webUrl);
					var file = ctx.Web.GetFileByServerRelativeUrl(serverRelativeUrl);
					fileHandler.Invoke(ctx, file);
					done = true;
				}
				catch (ServerException sex)
				{
					//Console.WriteLine(sex);
					MessageBox.Show(sex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					done = true;
				}
				catch (ClientRequestException ex)
				{
					webUrl = webUrl.Substring(0, webUrl.LastIndexOf('/'));
				}
				return done;
			}, () =>
			{
				throw new Exception("Unable to work with sharepoint. Check the url of the file. " + fullUrl);
			});
		}
	}
}
