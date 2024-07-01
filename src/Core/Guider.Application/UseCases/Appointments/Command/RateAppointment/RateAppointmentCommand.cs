using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Command.RateAppointment
{
    public class RateAppointmentCommand :IRequest<BaseResponse>
    {
        public int AppointmentId { get; set; }
        public int Rate {  get; set; }
    }
}
