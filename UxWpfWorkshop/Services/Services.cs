using Microsoft.Extensions.DependencyInjection;
using UxWpfWorkshop.Services.Impl;

namespace UxWpfWorkshop.Services
{
    internal static class Services
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // add your services here
            services.AddSingleton<IDataService, DataService>();

            return services;
        }
    }
}
