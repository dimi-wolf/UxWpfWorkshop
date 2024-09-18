using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UxWpfWorkshop.ViewModels.Shell;

namespace UxWpfWorkshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            mainContent.Content = serviceProvider.GetService<MainViewModel>();
        }
    }
}