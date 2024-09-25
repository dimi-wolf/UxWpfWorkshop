using Microsoft.Extensions.DependencyInjection;
using UxWpfWorkshop.ViewModels.DataLoad;
using UxWpfWorkshop.ViewModels.Home;
using UxWpfWorkshop.ViewModels.Shell;

namespace UxWpfWorkshop.ViewModels
{
    internal static class ViewModels
    {
        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            // shell
            services.AddSingleton<HeaderViewModel>();
            services.AddSingleton<NavigationViewModel>();
            services.AddSingleton<MainViewModel>();

            // add your view models here
            services.AddTransient<HomeViewModel>();
            services.AddTransient<DataLoadViewModel>();

            return services;
        } 
    }
}
