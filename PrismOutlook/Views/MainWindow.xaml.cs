using Prism.Regions;
using PrismOutlook.Core;
using System.Windows;
using Telerik.Windows.Controls;

namespace PrismOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        private readonly IRegionManager _regionManager;

        public MainWindow(IRegionManager regionManager)
        {
            StyleManager.ApplicationTheme = new Office2016Theme();
            InitializeComponent();
            _regionManager = regionManager;
        }

        private void RadOutlookBar_SelectionChanged(object sender, RadSelectionChangedEventArgs e)
        {
            if (((RadOutlookBar)sender).SelectedItem is IOutlookBarGroup group)
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, group.DefaultNavigationPath);
            }
        }
    }
}
