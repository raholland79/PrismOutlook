using Prism.Commands;
using PrismOutlook.Business;
using PrismOutlook.Core;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismOutlook.Modules.Mail.ViewModels
{
    public class MailGroupViewModel : ViewModelBase
    {
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private DelegateCommand<ReadOnlyCollection<object>> _selectedCommand;
        private readonly IApplicationCommands _applicationCommands;

        public DelegateCommand<ReadOnlyCollection<object>> SelectedCommand =>
            _selectedCommand ?? (_selectedCommand = new DelegateCommand<ReadOnlyCollection<object>>(ExecuteSelectedCommand));

        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
            GenerateMenu();
            _applicationCommands = applicationCommands;
        }

        void ExecuteSelectedCommand(ReadOnlyCollection<object> parameter)
        {
            var item = parameter.FirstOrDefault();
            if (item is NavigationItem navigationItem) 
            {
                _applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);
            }
           
        }

        void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem { Caption = "Personal Folder", NavigationPath = "MailList?id=Default" };           
            root.Items.Add(new NavigationItem { Caption = "Inbox", NavigationPath = "MailList?id=Inbox" });
            root.Items.Add(new NavigationItem { Caption = "Deleted", NavigationPath = "MailList?id=Deleted" });
            root.Items.Add(new NavigationItem { Caption = "Sent", NavigationPath = "MailList?id=Sent" });
           
            Items.Add(root);
        }
    }
}
