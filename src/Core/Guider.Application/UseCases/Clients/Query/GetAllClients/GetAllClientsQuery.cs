using Guider.Application.UseCases.Clients.Query.GetClientDetails;
using MediatR;

namespace Guider.Application.UseCases.Clients.Query.GetAllClients
{
    public class GetAllClientsQuery : IRequest<List<ClienttoReturnVM>>
    {
    }
}
