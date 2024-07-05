using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantSearch
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
