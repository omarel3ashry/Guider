using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Command.UpdateImage
{
    public class UpdateConsultantImageCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
}
