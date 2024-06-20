using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules.Command.UpdateSchedule
{
    public class UpdateScheduleDto
    {
       
        public DateTime Date { get; set; }
        public float TimeSpan { get; set; }
    }
}
