using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows;
using UxWpfWorkshop.Services;
using UxWpfWorkshop.ViewModels;

namespace UxWpfWorkshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly string? _assemblyLocation = Assembly.GetEntryAssembly()?.Location;
        private static readonly string _assemblyDir = Path.GetDirectoryName(_assemblyLocation) ?? string.Empty;

        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(_assemblyDir); })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
                services.ConfigureServices();
                services.ConfigureViewModels();
                services.AddSingleton<MainWindow>();
            }).Build();

        public static T? GetService<T>() where T : class => _host.Services.GetService<T>();

        private async void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync().ConfigureAwait(true);
            GetService<MainWindow>()?.Show();
        }

        private async void OnApplicationExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync().ConfigureAwait(true);
            _host.Dispose();
        }
    }
}
