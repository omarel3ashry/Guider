using Microsoft.Extensions.DependencyInjection;

namespace Guider.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddSignalR();
            return services;
        }
    }
}
