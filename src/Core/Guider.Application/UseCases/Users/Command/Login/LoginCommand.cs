using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Users.Command.Login
{
    public class LoginCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
