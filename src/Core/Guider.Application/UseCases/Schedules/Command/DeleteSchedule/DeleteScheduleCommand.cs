using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Schedules.Command.DeleteSchedule
{
    public class DeleteScheduleCommand : IRequest<BaseResponse>
    {
        public int ConsultantId { get; set; }
        public DateTime Date { get; set; }
    }
}
