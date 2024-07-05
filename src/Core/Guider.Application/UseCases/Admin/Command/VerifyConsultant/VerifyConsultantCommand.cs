using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Admin.Command.VerifyConsultant
{
    public class VerifyConsultantCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
