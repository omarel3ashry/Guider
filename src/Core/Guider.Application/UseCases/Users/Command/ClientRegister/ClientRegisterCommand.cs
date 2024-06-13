using Guider.Application.Responses;
using MediatR;


namespace Guider.Application.UseCases.Users.Command.ClientRegister
{
    public class ClientRegisterCommand : IRequest<AuthenticationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
