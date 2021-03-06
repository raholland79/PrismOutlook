﻿using Prism.Regions;
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
            StyleManager.ApplicationTheme = new Office2019Theme();
            InitializeComponent();
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
