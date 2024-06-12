using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>,IClientRepository
    {
        public ClientRepository(GuiderContext context):base(context)
        {
            
        }
       public async Task<List<Client>> GetAllClientWithAppointments()
        {
            return await context.Clients.Include(e => e.User)
                .Include(e => e.Appointments).
                ThenInclude(a => a.Consultant).
                 ThenInclude(con => con.User).
                ToListAsync();


        }
      public async Task<Client> GetClientWithAppointments(int id)
        {
            return await context.Clients.Include(e => e.User)
                .Include(e => e.Appointments)
                .ThenInclude(a => a.Consultant)
                 .ThenInclude(con => con.User).
                FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
