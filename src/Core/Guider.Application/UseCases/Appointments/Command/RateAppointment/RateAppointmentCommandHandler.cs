using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Command.RateAppointment
{
    internal class RateAppointmentCommandHandler : IRequestHandler<RateAppointmentCommand, BaseResponse>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public RateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<BaseResponse> Handle(RateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            if (request.Rate >= 1 && request.Rate <= 5)
            {
                await _appointmentRepository.UpdateAppointmentRateAsync(request.AppointmentId, request.Rate);
                response.Success = true;
                response.Message = "Rate Set successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Invalid Rate Range";
            }
            return response;
        }
    }
}
