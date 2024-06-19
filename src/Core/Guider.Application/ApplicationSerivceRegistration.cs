using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Stripe;
using System.Reflection;
using MediatR;
using AutoMapper;
using FluentValidation;
using Guider.Application.UseCases.Users.Command.ClientRegister;
using Guider.Application.UseCases.Users.Command.ConsultantRegister;

namespace Guider.Application
{
    public static class ApplicationSerivceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IValidator<ClientRegisterCommand>, ClientRegisterCommandValidator>();
            services.AddScoped<IValidator<ConsultantRegisterCommand>, ConsultantRegisterCommandValidator>();
            

            StripeConfiguration.ApiKey= configuration["Stripe:SecretKey"];
            return services;
        }
    }
}
