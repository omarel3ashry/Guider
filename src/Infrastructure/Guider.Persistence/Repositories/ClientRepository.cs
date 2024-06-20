using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>,IClientRepository
    {
        public ClientRepository(GuiderContext context):base(context)
        {
            
        }

       public async Task<List<Client>> GetAllClientWithAppointments()
        {
            return await _context.Clients.Include(e => e.User)
                .Include(e => e.Appointments).
                ThenInclude(a => a.Consultant).
                 ThenInclude(con => con.User).
                 Where(e=>!e.User.IsDeleted).
                ToListAsync();


        }
      public async Task<Client> GetClientWithAppointments(int id)
        {
            return await _context.Clients.Include(e => e.User)
                .Include(e => e.Appointments)
                .ThenInclude(a => a.Consultant)
                 .ThenInclude(con => con.User).
                FirstOrDefaultAsync(e => e.Id == id&& !e.User.IsDeleted);
        }
       
    }
}
