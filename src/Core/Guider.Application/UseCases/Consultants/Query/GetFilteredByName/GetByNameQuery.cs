using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.GetFiltered;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetFilteredByName
{
    public class GetByNameQuery : IRequest<BaseResponse<PaginatedList<FilteredConsultantDto, Consultant>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
    }
}
