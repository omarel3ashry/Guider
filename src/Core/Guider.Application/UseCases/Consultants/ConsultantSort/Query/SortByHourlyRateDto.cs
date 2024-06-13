using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSortt.Query
{
    public class SortByHourlyRateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public float Rate { get; set; }
        public float HourlyRate { get; set; }
        public string Image { get; set; }
    }
}
