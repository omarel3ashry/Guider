using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(GuiderContext context) : base(context)
        {

        }
        public async Task<(List<Appointment> Appointments, int TotalCount)> GetSortedByRateAsync(bool ascending, int page, int pageSize)
        {
            var query  = _context.Appointment
               .Include(a => a.Consultant)
                   .ThenInclude(c => c.User)
               .Include(a => a.Consultant)
                   .ThenInclude(c => c.SubCategory)
                       .ThenInclude(sc => sc.Category)
               .AsQueryable();

            query = ascending ? query.OrderBy(a => a.Rate) : query.OrderByDescending(a => a.Rate);

            var totalCount = await query.CountAsync();
            var appointments = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return (appointments, totalCount);
        }
        
    }
}
