using MediatR;

namespace Guider.Application.UseCases.Clients.Query.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<ClienttoReturnVM>
    {
        public int Id { get; set; }
    }
}
