using Guider.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Guider.Application.UseCases.Consultants.Command.UpdateImage
{
    public class UpdateConsultantImageCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
