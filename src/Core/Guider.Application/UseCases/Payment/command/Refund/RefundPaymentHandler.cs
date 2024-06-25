using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Transactions.Dto;
using Guider.Domain.Enums;
using MediatR;
using Stripe;
using Transaction = Guider.Domain.Entities.Transaction;

namespace Guider.Application.UseCases.Payment.Command.Refund
{
    public class RefundPaymentHandler : IRequestHandler<RefundPaymentCommand, Stripe.Refund>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public RefundPaymentHandler(IAppointmentRepository appointmentRepository,
                                    ITransactionRepository transactionRepository,
                                    IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }
        public async Task<Stripe.Refund> Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
        {

            //  Get the appointment details
            var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
            var transaction = await _transactionRepository.GetByAppointmentIdAsync(request.AppointmentId);
            // Retrieve the PaymentIntent to get the amount
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(transaction.PaymentIntentId);

            // Create the refund options
            var options = new RefundCreateOptions
            {
                PaymentIntent = transaction.PaymentIntentId
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
                PaymentIntentId = transaction.PaymentIntentId
            };
            // Send the command to add a transaction
            var mappedtransaction = _mapper.Map<Transaction>(TransactionToAddDto);
            await _transactionRepository.AddAsync(mappedtransaction);
            return refund;
        }
    }
}