using Prism.Regions;
using PrismOutlook.Core;
using Telerik.Windows.Controls;

namespace PrismOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
       
        private readonly IApplicationCommands _appCommands;

        public MainWindow(IApplicationCommands appCommands)
        {
            InitializeComponent();
            StyleManager.ApplicationTheme = new Office2016Theme();
            _appCommands = appCommands;
        }

        private void RadOutlookBar_SelectionChanged(object sender, RadSelectionChangedEventArgs e)
        {
            if (((RadOutlookBar)sender).SelectedItem is IOutlookBarGroup group)
            {
                _appCommands.NavigateCommand.Execute(group.DefaultNavigationPath);
                //_regionManager.RequestNavigate(RegionNames.ContentRegion, group.DefaultNavigationPath);
            }
        }
    }
}
