using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repository
{
    public class ConsultantRepository : BaseRepository<Consultant>, IConsultantRepository
    {
        public ConsultantRepository(GuiderContext context) : base(context)
        {

        }
        public async Task<List<Consultant>> GetAllConsultantsAsync()
        {
            return await _context.Consultants
                 .Include(c => c.User) 
                .Include(c => c.SubCategory)
                .ThenInclude(sc => sc.Category)
                .Include(c => c.Appointments)
                .ThenInclude(a => a.Client)
                .ToListAsync();
        }
        public async Task<List<Consultant>> GetSortedByHourlyRateAsync(bool ascending)
        {
            var query = _context.Consultants
               .Include(c => c.User)
               .Include(c => c.SubCategory)
                   .ThenInclude(sc => sc.Category);

            if (ascending)
            {
                return await query.OrderBy(c => c.HourlyRate).ToListAsync();
            }
            else
            {
                return await query.OrderByDescending(c => c.HourlyRate).ToListAsync();
            }
        }
        public async Task<List<Consultant>> GetConsultantsByUserNameAsync(string searchQuery)
        {
            var consultants = await _context.Consultants
       .Include(c => c.User)
       .Include(c => c.SubCategory)
           .ThenInclude(sc => sc.Category)
       .Where(c => c.User.UserName.Contains(searchQuery))
       .ToListAsync();

            return consultants;
        }
        public async Task<List<Consultant>> GetPaginatedConsultantsAsync(int page, int pageSize)
        {
            return await _context.Consultants
                                 .Include(c => c.User)
                                 .Include(c => c.SubCategory)
                                 .ThenInclude(sc => sc.Category)
                                 .Include(c => c.Appointments) 
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}
