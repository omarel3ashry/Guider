using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Clients.Command.UpdateImage
{
    public class UpdateClientImageCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
    }
}
