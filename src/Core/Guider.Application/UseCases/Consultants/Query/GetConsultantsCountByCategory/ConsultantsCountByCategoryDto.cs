using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantsCountByCategory
{
    public class ConsultantsCountByCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ConsultantsCount { get; set; }
    }
}
