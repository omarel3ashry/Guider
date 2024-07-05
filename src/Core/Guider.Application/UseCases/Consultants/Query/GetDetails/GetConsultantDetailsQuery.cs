using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.GetAll;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetDetails
{
    public class GetConsultantDetailsQuery : IRequest<BaseResponse<ConsultantVM>>
    {
        public int Id { get; set; }
    }
}
