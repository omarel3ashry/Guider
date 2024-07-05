using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<List<Client>> GetAllClientWithAppointments();
        Task<Client> GetClientWithAppointments(int id);

    }
}
