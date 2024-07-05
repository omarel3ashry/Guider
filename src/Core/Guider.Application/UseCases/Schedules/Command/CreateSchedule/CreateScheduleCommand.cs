using MediatR;

namespace Guider.Application.UseCases.Schedules.Command.CreateSchedule
{
    public class CreateScheduleCommand : IRequest<bool>
    {
        public int ConsultantId { get; set; }
        public List<CreateScheduleDto> Schedules { get; set; }
    }

}
