using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetAll
{
    public class GetConsultantListQuery : IRequest<BaseResponse<List<ConsultantVM>>>
    {
    }
}
