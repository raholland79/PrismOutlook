using System;
using PrismOutlook.Business;
using PrismOutlook.Core;
using System.Linq;
using Telerik.Windows.Controls;

namespace PrismOutlook.Modules.Mail.Menus
{
    /// <summary>
    /// Interaction logic for MailGroup.xaml
    /// </summary>
    public partial class MailGroup : RadOutlookBarItem, IOutlookBarGroup
    {
        public MailGroup()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(RadOutlookBarItem));
        }

        public string DefaultNavigationPath
        {
            get
            {
                if ((_treeListview.SelectedItems.Count() > 0) && 
                    (_treeListview.SelectedItems[0] is NavigationItem item))
                {
                    return item.NavigationPath;
                }
                
                return "MailList?id=Default";
            }
        }
    }
}
 