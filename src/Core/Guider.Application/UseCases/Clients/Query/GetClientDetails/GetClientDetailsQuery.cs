using MediatR;

namespace Guider.Application.UseCases.Clients.Query.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<UserClientDto>
    {
        public int Id { get; set; }
    }
}
