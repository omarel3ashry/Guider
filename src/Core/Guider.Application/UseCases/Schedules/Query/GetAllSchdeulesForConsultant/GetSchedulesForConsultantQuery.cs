using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules.Query.GetAllSchdeulesForConsultant
{
    public class GetSchedulesForConsultantQuery:IRequest<List<ScheduleDto>>
    {
        public int ConsultantId { get; set; }
        public GetSchedulesForConsultantQuery(int consultantId)
        {
            ConsultantId = consultantId;
        }

        
    }
}
