using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using UxWpfWorkshop.Messages;

namespace UxWpfWorkshop.ViewModels.Shell
{
    public class MainViewModel : ObservableRecipient
    {
        private readonly HeaderViewModel _headerViewModel;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IServiceProvider _serviceProvider;

        private object? _mainContent;

        public MainViewModel(
            HeaderViewModel headerViewModel,
            NavigationViewModel navigationViewModel,
            IServiceProvider serviceProvider,
            IMessenger messenger)
            : base(messenger)
        {
            _headerViewModel = headerViewModel;
            _navigationViewModel = navigationViewModel;
            _serviceProvider = serviceProvider;

            IsActive = true;
        }

        public HeaderViewModel Header => _headerViewModel;

        public NavigationViewModel Navigation => _navigationViewModel;

        public object? MainContent
        {
            get => _mainContent;
            set => SetProperty(ref _mainContent, value);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            Messenger.Register<NavigationMessage>(this, NavigationMessageReceived);
        }

        private void NavigationMessageReceived(object sender, NavigationMessage message)
        {
            if (MainContent != null && MainContent.GetType() == message.ContentType)
            {
                return;
            }

            object? content = _serviceProvider.GetService(message.ContentType);
            MainContent = content;
        }
    }
}
