using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetDetails
{
    public class GetConsultantDetailsQuery : IRequest<BaseResponse<ConsultantDto>>
    {
        public int Id { get; set; }
    }
}
