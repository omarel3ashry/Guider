using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules.Command.CreateSchedule
{
    public class CreateScheduleCommand : IRequest<bool>
    {
        public int ConsultantId { get; set; }
        public List<CreateScheduleDto> Schedules { get; set; }
    }

}
