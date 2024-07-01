using Guider.Application.Responses;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultants
{
    public class GetUnVerifiedConsultantsRequest : IRequest<BaseResponse<List<ConsultantListDto>>>
    {
    }
}
