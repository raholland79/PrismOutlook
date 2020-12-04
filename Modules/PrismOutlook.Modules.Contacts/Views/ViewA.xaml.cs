using PrismOutlook.Core;
using PrismOutlook.Modules.Contacts.Menus;
using System.Windows.Controls;

namespace PrismOutlook.Modules.Contacts.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    /// 
    [DependantView(RegionNames.RibbonRegion, typeof(HomeTab))]
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();
        }
    }
}
