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
        public async Task<(List<Consultant> Consultants, int TotalCount)> GetSortedByHourlyRateAsync(bool ascending, int page, int pageSize)
        {
            var baseQuery = _context.Consultants
                .Include(c => c.User)
                .Include(c => c.SubCategory)
                    .ThenInclude(sc => sc.Category)
                .AsQueryable();

            var sortedQuery = ascending
                ? baseQuery.OrderBy(c => c.HourlyRate)
                : baseQuery.OrderByDescending(c => c.HourlyRate);

            var totalCount = await sortedQuery.CountAsync();
            var consultants = await sortedQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (consultants, totalCount);
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
        public async Task<(List<Consultant> Consultants, int TotalCount)> SearchConsultantsAsync(string searchQuery, int page, int pageSize)
        {
            var query = _context.Consultants
                .Include(c => c.User)
                .Include(c => c.SubCategory)
                    .ThenInclude(sc => sc.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(c => c.User.UserName.Contains(searchQuery));
            }

            var totalCount = await query.CountAsync();
            var consultants = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (consultants, totalCount);
        }

    }
}
