using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Appointments.Dto;
using Guider.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Payment.command.UserPayment
{
    public class CreateOrUpdatePaymentIntentHandler : IRequestHandler<CreateOrUpdatePaymentIntentCommand, AppointmentToReturnDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IRepository<Appointment> _appointmentRepo;
        private readonly IMapper _mapper;
        public CreateOrUpdatePaymentIntentHandler(IConfiguration configuration, IAppointmentRepository appointmentRepository, IRepository<Appointment> appointmentRepo, IMapper mapper)
        {
            _configuration = configuration;
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
            _appointmentRepository=appointmentRepository;

        }

        public async Task<AppointmentToReturnDto> Handle(CreateOrUpdatePaymentIntentCommand request, CancellationToken cancellationToken)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(request.AppointmentId);
            if (appointment == null) throw new ArgumentException("Appointment not found.");
            //calculate the amount
            var amount = appointment.Duration * appointment.Consultant.HourlyRate;
            if (amount < 0.50f) throw new ArgumentException("The amount must be at least 50 cents.");
            var paymentIntentService = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrEmpty(appointment.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await paymentIntentService.CreateAsync(options);
                appointment.PaymentIntentId = paymentIntent.Id;
                appointment.ClientSecretKey = paymentIntent.ClientSecret;
            }
            else
            {
                var updateOptions = new PaymentIntentUpdateOptions
                {
                    Amount = (long)(amount * 100),
                };
                await paymentIntentService.UpdateAsync(appointment.PaymentIntentId, updateOptions);
            }
            await _appointmentRepo.UpdateAsync(appointment);

           return _mapper.Map<AppointmentToReturnDto>(appointment); 
        }
    }
}
