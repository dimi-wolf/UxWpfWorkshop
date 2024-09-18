using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace UxWpfWorkshop.ViewModels.Shell
{
    public class HeaderViewModel : ObservableRecipient
    {
        private string _title = "MVVM Showcase";

        public HeaderViewModel(IMessenger messenger)
            : base(messenger)
        {
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
