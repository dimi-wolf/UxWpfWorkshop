using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace UxWpfWorkshop.ViewModels.Home
{
    public class HomeViewModel : ObservableRecipient
    {
        public HomeViewModel(IMessenger messenger)
            : base(messenger)
        {
        }
    }
}
