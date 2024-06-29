using Guider.Application.Responses;
using Guider.Domain.Common;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Query.GetAllForConsultant
{
    public class GetAllAppointmentsForUserQuery<T> : IRequest<BaseResponse<PaginatedList<AppointmentListDto, Appointment>>> where T:Consumer
    {
        public int Id { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int State { get; set; }
    }
}
