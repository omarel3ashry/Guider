using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Dto;
using Guider.Application.UseCases.Appointments.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.command.UpdateAppointment
{
    public class UpdateAppointmentCommand:IRequest<AppointmentToReturnDto>
    {
        public AppointmentToUpdateDto appointmentToUpdateDto {  get; set; }

    }
}
