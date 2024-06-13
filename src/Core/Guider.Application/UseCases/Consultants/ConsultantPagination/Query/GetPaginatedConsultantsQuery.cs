using Guider.Application.UseCases.Consultants.ConsultantSearch.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantPagination.Query
{
    public class GetPaginatedConsultantsQuery : IRequest<List<ConsultantDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedConsultantsQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}