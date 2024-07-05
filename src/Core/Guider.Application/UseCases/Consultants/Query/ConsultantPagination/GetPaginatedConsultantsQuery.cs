using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantPagination
{
    public class GetPaginatedConsultantsQuery : IRequest<PaginatedConsultantDto>
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