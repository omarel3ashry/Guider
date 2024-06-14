using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules.Query.GetAllSchdeulesForConsultant
{
    public class ScheduleDto
    {
        public int ConsultantId { get; set; }
        public DateTime Date { get; set; }
        public float TimeSpan { get; set; }
    }
}
