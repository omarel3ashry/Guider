using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantsCountByCategory
{
    public class GetConsultantsCountByCategoryQuery:IRequest<List<ConsultantsCountByCategoryDto>>
    {
    }
}
