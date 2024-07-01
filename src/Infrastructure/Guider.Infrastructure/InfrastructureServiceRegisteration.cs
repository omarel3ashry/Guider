using Guider.Application.Contracts.Infrastructure;
using Guider.Infrastructure.Jobs;
using Guider.Infrastructure.Meeting;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Guider.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            services.AddHangfire(c =>
                c.UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(config.GetConnectionString("HangfireConnection")));
            services.AddHangfireServer(x=>x.SchedulePollingInterval=TimeSpan.FromSeconds(5));
            services.AddSignalR();
            services.AddScoped<IBackgroundJob, BackgroundJobs>();
            services.AddSingleton<MeetingHub>();
            return services;
        }
    }
}
