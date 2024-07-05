using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantBySubCategoryId
{
    public class GetConsultantBySubCategoryIdQuery : IRequest<PaginatedList<ConsultantDto, Consultant>>
    {
        public int SubCategoryId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }


    }
}
