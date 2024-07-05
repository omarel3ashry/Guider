using MediatR;

namespace Guider.Application.UseCases.Clients.Command.DeleteClient
{
    public class DeleteClientCommand : IRequest<int>
    {
        public int ClientId { get; set; }
    }
}
