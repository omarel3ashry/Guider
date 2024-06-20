using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules.Command.CreateSchedule
{
    public class CreateScheduleDto
    {
        public DateTime Date { get; set; }
        public float TimeSpan { get; set; }
    }
}
