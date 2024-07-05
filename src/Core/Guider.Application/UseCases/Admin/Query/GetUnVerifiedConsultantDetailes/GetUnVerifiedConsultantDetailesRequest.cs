using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultantDetailes
{
    public class GetUnVerifiedConsultantDetailesRequest : IRequest<BaseResponse<ConsultantDetailsDto>>
    {
        public int Id { get; set; }
    }
}
