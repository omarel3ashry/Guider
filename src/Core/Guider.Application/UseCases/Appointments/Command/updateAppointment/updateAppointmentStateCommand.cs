using Guider.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Command.updateAppointment
{
    public class updateAppointmentStateCommand:IRequest
    {
        public int Id { get; set; }
        public AppointmentState State { get; set; }
        public float? Rate {  get; set; }
    
    }
}
