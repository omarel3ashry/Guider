using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantsAll.Query
{
    public class GetAllConsultantsQuery : IRequest<List<ConsultantDto>>
    {
    }
}
