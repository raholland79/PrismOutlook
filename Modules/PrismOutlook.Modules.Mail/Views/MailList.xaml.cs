﻿using PrismOutlook.Core;
using PrismOutlook.Modules.Mail.Menus;
using System.Windows.Controls;

namespace PrismOutlook.Modules.Mail.Views
{
    /// <summary>
    /// Interaction logic for MailList
    /// </summary>
    /// 
    [DependantView(RegionNames.RibbonRegion, typeof(HomeTab))]
    public partial class MailList : UserControl, ISupportDataContext
    {
        public MailList()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(UserControl));
        }
    }
}
