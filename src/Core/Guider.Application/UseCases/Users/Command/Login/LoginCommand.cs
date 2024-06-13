using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Users.Command.Login
{
    public class LoginCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
