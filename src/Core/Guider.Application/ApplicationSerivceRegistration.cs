using FluentValidation;
using Guider.Application.UseCases.client.Command.CreateClient;
using Guider.Application.UseCases.consultant.Command.CreateConsultant;
using Guider.Application.UseCases.consultant.Command.UpdateConsultant;
using Microsoft.Extensions.DependencyInjection;

namespace Guider.Application
{
    public static class ApplicationSerivceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped<IValidator<CreateConsultantCommand>, CreateConsultantCommandValidator>();
            services.AddScoped<IValidator<UpdateConsultantCommand>, UpdateConsultantCommandValidator>();
            services.AddScoped<IValidator<ClientCreateCommand>, CreateClientCommandValidator>();
           

            return services;
        }
    }
}
