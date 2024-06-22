using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Appointments.Query;
using Guider.Application.UseCases.Transactions.Command.AddTransaction;
using Guider.Application.UseCases.Transactions.Dto;
using Guider.Domain.Enums;
using MediatR;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction = Guider.Domain.Entities.Transaction;


namespace Guider.Application.UseCases.Payment.command.PayToconsultant
{
    public class PayToConsultantCommandHandler : IRequestHandler<PayToConsultantCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly ITransactionRepository _transactionRepository;



        public PayToConsultantCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IRepository<Transaction> transactionRepo, ITransactionRepository transactionRepository)
        {


            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _transactionRepo = transactionRepo;
            _transactionRepository = transactionRepository;

        }
        public async Task<bool> Handle(PayToConsultantCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.appointmentId);
            var transaction = await _transactionRepository.GetByAppointmentIdAsync(request.appointmentId);
            // Retrieve the PaymentIntent to get the amount
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(transaction.PaymentIntentId);

            //consultant pay amount
            var consultantPaymnetAmount = paymentIntent.Amount - 10;
            var consultantTransaction = new TransactionToAddDto()
            {
                Type = TransactionType.Payment,
                Date = DateTime.Now,
                Amount = consultantPaymnetAmount,
                UserId = appointment.Consultant.UserId,
                AppointmentId = request.appointmentId,
                PaymentIntentId = transaction.PaymentIntentId
            };

            var commisionAmount = (paymentIntent.Amount) * (10 / 100);
            var CommisionTransaction = new TransactionToAddDto()
            {
                Type = TransactionType.Commision,
                Date = DateTime.Now,
                Amount = commisionAmount,
                UserId = appointment.Client.UserId,
                AppointmentId = request.appointmentId,
                PaymentIntentId = transaction.PaymentIntentId
            };
            var mappedCommisionTransaction = _mapper.Map<Transaction>(CommisionTransaction);
            var mappedconsultantTransaction = _mapper.Map<Transaction>(consultantTransaction);
            await _transactionRepo.AddAsync(mappedCommisionTransaction);
            await _transactionRepo.AddAsync(mappedconsultantTransaction);
            return true;
        }
    }
}