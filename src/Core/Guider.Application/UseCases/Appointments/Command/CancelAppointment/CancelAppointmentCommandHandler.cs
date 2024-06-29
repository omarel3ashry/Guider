using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;
using Stripe;

namespace Guider.Application.UseCases.Appointments.Command.CancelAppointment
{
    internal class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, BaseResponse>
    {
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IScheduleRepository _scheduleRepo;

        public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepo,
                                               ITransactionRepository transactionRepo,
                                               IScheduleRepository scheduleRepo)
        {
            _appointmentRepo = appointmentRepo;
            _transactionRepo = transactionRepo;
            _scheduleRepo = scheduleRepo;
        }

        public async Task<BaseResponse> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepo.GetWithTransactionAsync(request.AppointmentId);

            if (appointment == null)
                throw new NotFoundException("Appointment not found!");

            if (request.ClientUserId != appointment.Client.UserId)
                throw new NotAuthorizedException("You are not authorized to do this action!");

            var transaction = appointment.Transactions.FirstOrDefault(e => e.Type == TransactionType.Reservation);

            // Retrieve the PaymentIntent to get the amount
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(transaction!.PaymentIntentId);

            // Create the refund options
            var options = new RefundCreateOptions
            {
                PaymentIntent = transaction.PaymentIntentId
            };
            // Create the refund
            var service = new RefundService();
            var refund = await service.CreateAsync(options);

            Transaction refundTransaction = new Transaction()
            {
                Type = TransactionType.Refund,
                Date = DateTime.Now,
                Amount = paymentIntent.Amount,
                UserId = appointment.Client.UserId,
                AppointmentId = request.AppointmentId,
                PaymentIntentId = transaction.PaymentIntentId
            };

            bool added = await _transactionRepo.AddAsync(refundTransaction);
            if (added)
            {
                appointment.State = AppointmentState.Canceled;
                await _appointmentRepo.UpdateAsync(appointment);
                await _scheduleRepo.UpdateScheduleStateAsync(appointment.ConsultantId, appointment.Date, false, appointment.Duration);
                return new BaseResponse() { Message = "Appointment canceled and refund was sent." };
            }
            return new BaseResponse() { Success = false, Message = "Failed to cancel the appointment!" };
        }
    }
}
