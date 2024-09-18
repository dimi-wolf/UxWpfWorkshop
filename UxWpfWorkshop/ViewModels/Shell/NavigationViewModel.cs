using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using UxWpfWorkshop.Messages;
using UxWpfWorkshop.ViewModels.Home;

namespace UxWpfWorkshop.ViewModels.Shell
{
    public partial class NavigationViewModel : ObservableRecipient
    {
        public NavigationViewModel(IMessenger messenger)
            : base(messenger)
        {
        }

        [RelayCommand]
        private void NavigateHome()
        {
            Messenger.Send(new NavigationMessage(typeof(HomeViewModel)));
        }
    }
}
