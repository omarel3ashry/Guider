using Guider.Application.UseCases.Appointments.Dto;
using Guider.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.command.insertAppointment
{
    public class AddAppointmentCommand : IRequest<AppointmentToReturnDto>
    {
        public AppointmentState State { get; set; }

        public DateTime Date { get; set; }
        public float Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }


    }
}