using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantSort
{
    public class SortByHourlyRateQuery : IRequest<PaginatedConsultantDto>
    {
        public bool Ascending { get; }
        public int Page { get; set; }
        public int PageSize { get; set; }


        public SortByHourlyRateQuery(bool ascending, int page, int pageSize)
        {
            Ascending = ascending;
            Page = page;
            PageSize = pageSize;

        }
    }
}
