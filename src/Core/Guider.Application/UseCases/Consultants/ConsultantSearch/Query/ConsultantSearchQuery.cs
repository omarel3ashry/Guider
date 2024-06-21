using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSearch.Query
{
    public class ConsultantSearchQuery : IRequest<PaginatedConsultantDto>
    {
        public string SearchQuery { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }


        public ConsultantSearchQuery(string searchQuery, int Page, int PageSize)
        {
            SearchQuery = searchQuery;
            page = Page;
            pageSize = PageSize;

        }
    }
}
