using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Command.DeleteConsultant
{
    public class DeleteConsultantCommand : IRequest<BaseResponse<int>>
    {
        public int ConsultantId { get; set; }

    }
}
