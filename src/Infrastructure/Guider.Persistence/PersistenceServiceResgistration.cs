using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Guider.Persistence
{
    public static class PersistenceServiceResgistration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<GuiderContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DevConnection"));
            });
                
            return services;
        }
    }
}
