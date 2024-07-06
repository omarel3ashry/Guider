using Guider.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Guider.Application.UseCases.Clients.Command.UpdateImage
{
    public class UpdateClientImageCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
