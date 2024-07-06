using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultants
{
    public class GetUnVerifiedConsultantsRequest : IRequest<BaseResponse<List<ConsultantListDto>>>
    {
    }
}
