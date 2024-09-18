using Microsoft.Extensions.DependencyInjection;
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
            services.AddSingleton<HomeViewModel>();

            return services;
        } 
    }
}
