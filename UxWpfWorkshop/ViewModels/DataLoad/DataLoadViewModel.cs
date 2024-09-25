using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using UxWpfWorkshop.Services;

namespace UxWpfWorkshop.ViewModels.DataLoad
{
    public partial class DataLoadViewModel : ObservableRecipient
    {
        private readonly IDataService _dataService;
        private bool _isBusy;
        private string _sayHello = string.Empty;

        public DataLoadViewModel(IMessenger messenger, IDataService dataService)
            : base(messenger)
        {
            _dataService = dataService;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string SayHello
        {
            get => _sayHello;
            set => SetProperty(ref _sayHello, value);
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            try
            {
                // hier bin ich im UI-Thread
                IsBusy = true;
                SayHello = string.Empty;

                var data = await _dataService.GetDataAsync() // evtl. in einem anderen Thread
                    .ConfigureAwait(true);

                // hier bin ich wieder im UI-Thread
                SayHello = "Hello: " + data.Description;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
