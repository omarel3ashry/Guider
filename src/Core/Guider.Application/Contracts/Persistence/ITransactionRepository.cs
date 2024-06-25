using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<Transaction> GetByAppointmentIdAsync(int appoinmentid);
    }
}
