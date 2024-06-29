using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.GetAllForConsultant;
using Guider.Domain.Common;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Query.GetAppointmentsStatsForUser
{
    public class GetAppointmentsStatsForUserQuery <T>: IRequest<BaseResponse<AppointmentsStatsDto>> where T:Consumer
    {
        public int Id { get; set; }
    }
}
