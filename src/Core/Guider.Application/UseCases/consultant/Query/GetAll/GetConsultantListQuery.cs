using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Query.GetAll
{
    public class GetConsultantListQuery:IRequest<List<ConsultantListVM>>
    {
    }
}
