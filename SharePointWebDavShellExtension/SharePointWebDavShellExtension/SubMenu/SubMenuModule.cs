using Ninject.Modules;

namespace SharePointWebDavShellExtension
{
	public class SubMenuModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ISharePointToolStripItemSettings>().To<PublishToolStripSettings>();
			Bind<ISharePointToolStripItemSettings>().To<CheckinToolStripSettings>();
			Bind<ISharePointToolStripItemSettings>().To<CheckoutToolStripSettings>();
			Bind<ISharePointToolStripItemSettings>().To<DiscardCheckoutToolStripSettings>();
		}
	}
}