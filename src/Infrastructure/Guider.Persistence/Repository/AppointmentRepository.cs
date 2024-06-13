using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Guider.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repository
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(GuiderContext context) : base(context)
        {

        }
        public async Task<List<Appointment>> GetSortedByRateAsync(bool ascending)
        {
            var query = _context.Appointment
               .Include(a => a.Consultant)
                   .ThenInclude(c => c.User)
               .Include(a => a.Consultant)
                   .ThenInclude(c => c.SubCategory)
                       .ThenInclude(sc => sc.Category)
               .AsQueryable();
            if (ascending)
            {
                return await query.OrderBy(c => c.Rate).ToListAsync();
            }
            else
            {
                return await query.OrderByDescending(c => c.Rate).ToListAsync();
            }
        }
    }
}
