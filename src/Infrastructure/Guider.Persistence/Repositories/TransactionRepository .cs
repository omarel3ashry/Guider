using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        protected readonly GuiderContext _context;

        public TransactionRepository(GuiderContext context)
        {

            _context = context;
        }

        public async Task<Transaction> GetByAppointmentIdAsync(int appoinmentid)
        {
            var transaction = await _context.Transactions
         .FirstOrDefaultAsync(t => t.AppointmentId == appoinmentid && t.Type == Domain.Enums.TransactionType.Reservation);

            return transaction;
        }

    }
}