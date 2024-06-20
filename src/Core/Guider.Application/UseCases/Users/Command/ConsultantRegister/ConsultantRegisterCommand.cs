using Guider.Application.Responses;
using MediatR;


namespace Guider.Application.UseCases.Users.Command.ConsultantRegister
{
    public class ConsultantRegisterCommand : IRequest<AuthenticationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public int SubCategoryId { get; set; }
    }
}
