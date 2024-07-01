using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.TopConsultants
{
    public class TopConsultantsDto
    {
        public string ConsultantName { get; set; }
        public string Bio { get; set; }
        public string SubCategoryName { get; set; }
        public float HourlyRate { get; set; }
        public string? Image { get; set; }
        public float? AverageRate { get; set; }
    }
}
