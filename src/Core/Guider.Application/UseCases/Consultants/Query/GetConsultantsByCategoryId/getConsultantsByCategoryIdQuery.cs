using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantsByCategoryId
{
    public class getConsultantsByCategoryIdQuery : IRequest<PaginatedList<ConsultantDto, Consultant>>
    {


        public int categoryId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }



    }
}
