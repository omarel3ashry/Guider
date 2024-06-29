using MediatR;

namespace Guider.Application.UseCases.Schedules.Query.GetAllSchdeulesForConsultant
{
    public class GetSchedulesForConsultantQuery : IRequest<List<ScheduleDto>>
    {
        public int ConsultantId { get; set; }
        public GetSchedulesForConsultantQuery(int consultantId)
        {
            ConsultantId = consultantId;
        }


    }
}
