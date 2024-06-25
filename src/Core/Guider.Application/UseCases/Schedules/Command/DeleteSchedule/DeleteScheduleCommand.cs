using MediatR;

namespace Guider.Application.UseCases.Schedules.Command.DeleteSchedule
{
    public class DeleteScheduleCommand : IRequest<bool>
    {
        public int ConsultantId { get; set; }
        public DateTime Date { get; set; }
    }
}
