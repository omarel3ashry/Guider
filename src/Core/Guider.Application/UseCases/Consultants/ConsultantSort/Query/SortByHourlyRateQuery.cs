using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSortt.Query
{
    public class SortByHourlyRateQuery : IRequest<PaginatedConsultantDto>
    {
        public bool Ascending { get; }
        public int Page { get; set; }
        public int PageSize { get; set; }


        public SortByHourlyRateQuery(bool ascending, int page, int pageSize)
        {
            Ascending = ascending;
            Page=page;
            PageSize=pageSize;

        }
    }
}
