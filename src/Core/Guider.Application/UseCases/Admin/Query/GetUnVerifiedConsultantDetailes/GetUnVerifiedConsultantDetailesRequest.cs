using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultantDetailes
{
    public class GetUnVerifiedConsultantDetailesRequest : IRequest<BaseResponse<ConsultantDetailsDto>>
    {
        public int Id { get; set; }
    }
}
