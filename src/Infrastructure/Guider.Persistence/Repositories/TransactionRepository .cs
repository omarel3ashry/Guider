using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(GuiderContext context) : base(context) { }


        public async Task<Transaction> GetByAppointmentIdAsync(int appoinmentid)
        {
            var transaction = await _context.Transactions
         .FirstOrDefaultAsync(t => t.AppointmentId == appoinmentid && t.Type == Domain.Enums.TransactionType.Reservation);

            return transaction;
        }

        public async Task<List<Transaction>> GetTransactionsByUserId(int userId)
        {

            return await _context.Transactions
                  .Include(t => t.Appointment).ThenInclude(a=>a.Client).ThenInclude(a=>a.User).Include(t => t.Appointment)
            .ThenInclude(a => a.Consultant)
                .ThenInclude(c => c.User)
                  .Where(t => t.UserId == userId)
                  .ToListAsync();
        }
    }
}