using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantsByCategoryId
{
    public class getConsultantsByCategoryIdQuery:IRequest<PaginatedList<ConsultantDto,Consultant>>
    {
   
    
        public int categoryId {  get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

     

    }
}
