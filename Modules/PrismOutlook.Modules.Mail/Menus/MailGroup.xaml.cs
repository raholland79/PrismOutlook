using PrismOutlook.Business;
using PrismOutlook.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
                
                return "MailList";
            }
        }
    }
}
 