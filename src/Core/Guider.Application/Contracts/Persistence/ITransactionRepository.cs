using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface ITransactionRepository 
    {
        Task<Transaction> GetByAppointmentIdAsync(int appoinmentid);
    }
}
