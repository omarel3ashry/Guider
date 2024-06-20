using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
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
        public async Task<(List<Consultant> Consultants, int TotalCount)> GetPaginatedConsultantsAsync(int page, int pageSize)
        {
            var query = _context.Consultants
                                .Include(c => c.User)
                                .Include(c => c.SubCategory)
                                    .ThenInclude(sc => sc.Category)
                                .Include(c => c.Appointments)
                                .AsQueryable();

            var totalCount = await query.CountAsync();

            var consultants = await query
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            return (consultants, totalCount);
        }
        public async Task<List<Consultant>> GetConsultantsWithsubCategoryAndSchedule()
        {
            return await _context.Consultants
               .Include(e => e.SubCategory)
                    .ThenInclude(e => e.Category)
               .Include(e => e.User)
               .Include(e => e.Schedules)
               .Include(e => e.Appointments)
                     .ThenInclude(e => e.Client)
                        .ThenInclude(e => e.User)
               .Where(c => !c.User.IsDeleted)
               .ToListAsync();
        }
        public async Task<Consultant> GetConsultantWithsubCategoryAndSchedule(int id)
        {
            return await _context.Consultants
               .Include(e => e.SubCategory)
                    .ThenInclude(e => e.Category)
               .Include(e => e.User)
               .Include(e => e.Schedules)
               .Include(e => e.Appointments)
                    .ThenInclude(e => e.Client)
                        .ThenInclude(e => e.User)
               .FirstOrDefaultAsync(e => e.Id == id && !e.User.IsDeleted);
        }
        public async Task<Consultant> GetConsultantWithUserByIdAsync(int id)
        {
            return await _context.Consultants
                .Include(c => c.User)
                .Include(e => e.Appointments)
                .FirstOrDefaultAsync(c => c.Id == id && !c.User.IsDeleted);
        }
    }
}
