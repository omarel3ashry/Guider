using FluentValidation;
using Guider.Application.UseCases.Users.Command.ConsultantRegister;
using Microsoft.Extensions.DependencyInjection;

namespace Guider.Application
{
    public static class ApplicationSerivceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblyContaining(typeof(LoginCommandCommandValidator));
            
            return services;
        }
    }
}
