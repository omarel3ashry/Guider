using FluentValidation;
using Guider.Application.UseCases.client.Command.CreateClient;
using Guider.Application.UseCases.consultant.Command.UpdateBankAccount;
using Guider.Application.UseCases.consultant.Command.UpdateConsultant;
using Guider.Application.UseCases.consultant.Command.UpdateImage;
using Microsoft.Extensions.DependencyInjection;

namespace Guider.Application
{
    public static class ApplicationSerivceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
           
            services.AddScoped<IValidator<UpdateConsultantCommand>, UpdateConsultantCommandValidator>();
            services.AddScoped<IValidator<UpdateImageCommand>, UpdateImageCommandValidator>();
            services.AddScoped<IValidator<ClientCreateCommand>, CreateClientCommandValidator>();
            services.AddScoped<IValidator<UpdateBankAccountCommand>, UpdateBankAccountCommandValidator>();
           

            return services;
        }
    }
}
