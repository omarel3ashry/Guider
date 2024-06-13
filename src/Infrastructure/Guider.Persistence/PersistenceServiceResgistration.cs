using Guider.Application.Contracts.Persistence;
using Guider.Persistence.Data;
using Guider.Persistence.Repository;
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
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IConsultantRepository, ConsultantRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
