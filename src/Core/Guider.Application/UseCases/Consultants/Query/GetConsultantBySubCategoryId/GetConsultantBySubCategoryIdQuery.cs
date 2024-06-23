using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantBySubCategoryId
{
    public class GetConsultantBySubCategoryIdQuery : IRequest<PaginatedList<ConsultantDto, Consultant>>
    {
        public int SubCategoryId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }


    }
}
