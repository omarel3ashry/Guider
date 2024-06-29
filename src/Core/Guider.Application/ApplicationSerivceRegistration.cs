using FluentValidation;
using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.GetAllForConsultant;
using Guider.Application.UseCases.Appointments.Query.GetAppointmentsStatsForUser;
using Guider.Application.UseCases.Users.Command.ConsultantRegister;
using Guider.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace Guider.Application
{
    public static class ApplicationSerivceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddTransient<IRequestHandler<GetAllAppointmentsForUserQuery<Consultant>,BaseResponse<PaginatedList<AppointmentListDto,Appointment>>>, GetAllAppointmentsForUserHandler<Consultant>>();
            services.AddTransient<IRequestHandler<GetAllAppointmentsForUserQuery<Client>, BaseResponse<PaginatedList<AppointmentListDto, Appointment>>>, GetAllAppointmentsForUserHandler<Client>>();
            services.AddTransient<IRequestHandler<GetAppointmentsStatsForUserQuery<Client>, BaseResponse<AppointmentsStatsDto>>, GetAppointmentsStatsForUserQueryHandler<Client>>();
            services.AddTransient<IRequestHandler<GetAppointmentsStatsForUserQuery<Consultant>, BaseResponse<AppointmentsStatsDto>>, GetAppointmentsStatsForUserQueryHandler<Consultant>>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblyContaining(typeof(LoginCommandCommandValidator));
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];

            return services;
        }
    }
}
