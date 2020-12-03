using PrismOutlook.Core;
using Telerik.Windows.Controls;

namespace PrismOutlook.Modules.Contacts.Menus
{
    /// <summary>
    /// Interaction logic for ContactsGroup.xaml
    /// </summary>
    public partial class ContactsGroup : RadOutlookBarItem, IOutlookBarGroup
    {
        public ContactsGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath => "ViewA";
    }
}
