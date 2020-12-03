using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core.Regions;
using PrismOutlook.Modules.Contacts;
using PrismOutlook.Modules.Mail;
using PrismOutlook.Views;
using System.Windows;
using Telerik.Windows.Controls;

namespace PrismOutlook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MailModule>();
            moduleCatalog.AddModule<ContactsModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(RadOutlookBar), Container.Resolve<RadOutlookBarRegionAdapter>());
        }
    }
}
