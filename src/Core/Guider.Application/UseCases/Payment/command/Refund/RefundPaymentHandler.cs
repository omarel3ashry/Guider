using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Appointments.Query;
using Guider.Application.UseCases.Transactions.Command.AddTransaction;
using Guider.Application.UseCases.Transactions.Dto;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;
using Stripe;
using Stripe.FinancialConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Transaction = Guider.Domain.Entities.Transaction;

namespace Guider.Application.UseCases.Payment.command.Refund
{
    public class RefundPaymentHandler : IRequestHandler<RefundPaymentCommand, Stripe.Refund>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Transaction> _transactionRepo;
        public RefundPaymentHandler( IAppointmentRepository appointmentRepository, IMapper mapper, IRepository<Transaction> transactionRepo)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _transactionRepo = transactionRepo;

        }
        public async Task<Stripe.Refund> Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
        {

            //  Get the appointment details
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(request.AppointmentId);
            // Retrieve the PaymentIntent to get the amount
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(appointment.PaymentIntentId);

            // Create the refund options
            var options = new RefundCreateOptions
            {
                PaymentIntent = appointment.PaymentIntentId
            };
            // Create the refund
            var service = new RefundService();
            var refund = await service.CreateAsync(options);
            TransactionToAddDto TransactionToAddDto = new TransactionToAddDto()
            {
                Type = TransactionType.Refund,
                Date = DateTime.Now,
                Amount = paymentIntent.Amount,
                UserId = appointment.Client.UserId,
                AppointmentId = request.AppointmentId,
                PaymentIntentId = appointment.PaymentIntentId
            };
            // Send the command to add a transaction
            var mappedtransaction = _mapper.Map<Transaction>(TransactionToAddDto);
            await _transactionRepo.AddAsync(mappedtransaction);
            return refund;
        }
    }
}
