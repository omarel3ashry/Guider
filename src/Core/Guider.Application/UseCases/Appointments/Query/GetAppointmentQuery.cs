using Guider.Application.UseCases.Appointments.Dto;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Query
{
    public class GetAppointmentQuery : IRequest<AppointmentToReturnDto>
    {

  
        public int id {  get; set; }


    }
  
}
