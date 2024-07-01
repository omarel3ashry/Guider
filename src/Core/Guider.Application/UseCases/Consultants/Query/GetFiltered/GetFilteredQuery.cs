using Guider.Application.Responses;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetFiltered
{
    public class GetFilteredQuery : IRequest<BaseResponse<PaginatedList<FilteredConsultantDto,Consultant>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public bool SortByPrice { get; set; }
        public bool SortAsc { get; set; }
    }
}
