using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Guider.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<GuiderContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRegisterUserRepository<Client>, ClientRegisterRepository>();
            services.AddScoped<IRegisterUserRepository<Consultant>, ConsultantRegisterRepository>();
            services.AddScoped<UserManager<User>, UserManager<User>>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IConsultantRepository, ConsultantRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            return services;
        }
    }
}
