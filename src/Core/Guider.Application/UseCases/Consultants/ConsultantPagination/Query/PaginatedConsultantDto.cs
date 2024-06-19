using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantPagination.Query
{
    public class PaginatedConsultantDto
    {
        public List<ConsultantDto> Consultants { get; set; }
        public int TotalCount { get; set; }
    }
}
