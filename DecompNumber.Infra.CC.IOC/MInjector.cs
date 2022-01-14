using Microsoft.Extensions.DependencyInjection;
using DecompNumber.Domain.Services.Services;
using DecompNumber.Domain.Core.Interfaces.Services;

namespace DecompNumber.Infra.CC.IOC
{
    public static class MInjector
    {
        public static ServiceProvider GetProvider(IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<IServiceDecomposition, ServiceDecomposition>();
            return servicesCollection.BuildServiceProvider();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IServiceDecomposition, ServiceDecomposition>();
        }
    }
}
