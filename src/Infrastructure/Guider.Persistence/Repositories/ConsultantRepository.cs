using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
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

        public async Task<IQueryable<Consultant>> GetSortedByAverageRateAsync(bool ascending)
        {
            var consultants = _context.Consultants
            .Include(c => c.User)
            .Include(c => c.SubCategory)
            .ThenInclude(sc => sc.Category)
            .AsQueryable();

            consultants = ascending
                ? consultants.OrderBy(c => c.AverageRate)
                : consultants.OrderByDescending(c => c.AverageRate);

            return consultants;
        }
        public async Task UpdateConsultantAverageRate(int consultantId)
        {
            var consultant = await _context.Consultants
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.Id == consultantId);

            if (consultant != null)
            {
                var endedAppointments = consultant.Appointments.Where(a => a.State == AppointmentState.Completed);
                consultant.AverageRate = endedAppointments.Any()
                    ? endedAppointments.Average(a => a.Rate)
                    : 0;

                _context.Consultants.Update(consultant);
                await _context.SaveChangesAsync();
            }
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

        public async Task<IQueryable<Consultant>> getConsultantsbyCategoryId(int categoryId)
        {
            var consultants = _context.Consultants.Where(c => c.SubCategory.CategoryId == categoryId)
           .Include(c => c.User)
           .Include(c => c.SubCategory)
           .ThenInclude(sc => sc.Category)
           .AsQueryable();
            return consultants;
        }

        public async Task<IQueryable<Consultant>> getConsultantsbySubCategoryId(int subcategoryId)
        {
            var consultants = _context.Consultants.Where(c => c.SubCategory.Id == subcategoryId)
           .Include(c => c.User)
           .Include(c => c.SubCategory)
           .ThenInclude(sc => sc.Category)
           .AsQueryable();
            return consultants;
        }

        public async Task<IQueryable<Consultant>> GetSubCategorySortedByAverageRateAsync(bool ascending, int subcategoryId)
        {
            var consultants = _context.Consultants
            .Include(c => c.User)
            .Include(c => c.SubCategory)
            .ThenInclude(sc => sc.Category)
            .Where(c => c.SubCategoryId == subcategoryId)
            .AsQueryable();

            consultants = ascending
                ? consultants.OrderBy(c => c.AverageRate)
                : consultants.OrderByDescending(c => c.AverageRate);

            return consultants;
        }

        public async Task<IQueryable<Consultant>> GetSubCategorySortedByHourlyRateAsync(bool ascending, int subcategoryId)
        {
            var consultants = _context.Consultants
             .Include(c => c.User)
             .Include(c => c.SubCategory)
             .ThenInclude(sc => sc.Category)
             .Where(c => c.SubCategoryId == subcategoryId)
             .AsQueryable();

            consultants = ascending
                ? consultants.OrderBy(c => c.HourlyRate)
                : consultants.OrderByDescending(c => c.HourlyRate);

            return consultants;
        }
        public async Task<List<Category>> GetCategoriesWithConsultantsAsync()
        {
            return await _context.Categories
                .Include(c => c.SubCategories)
                    .ThenInclude(sc => sc.Consultants)
                .ToListAsync();
        }
        public async Task<List<Consultant>> GetTopConsultantsByAverageRateAsync()
        {
            return await _context.Consultants
                 .Include(c => c.User)
                 .Include(c => c.SubCategory)
                .Where(c => c.AverageRate.HasValue)
                .OrderByDescending(c => c.AverageRate)
                .Take(4)
                .ToListAsync();
        }

        public IQueryable<Consultant> GetAllByFilters(int categoryId, int subCategoryId, bool sortByPrice, bool sortAsc)
        {
            var query = _context.Consultants.Where(e => e.IsActive);

            if (subCategoryId != 0)
                query = _context.Consultants.Where(e => e.SubCategoryId == subCategoryId);
            else query = _context.Consultants.Include(e => e.SubCategory).Where(e => e.SubCategory.CategoryId == categoryId);

            if (sortByPrice)
                query = sortAsc ? query.OrderBy(e => e.HourlyRate) : query.OrderByDescending(e => e.HourlyRate);
            else query = sortAsc ? query.OrderBy(e => e.AverageRate) : query.OrderByDescending(e => e.AverageRate);

            return query;
        }

        public IQueryable<Consultant> GetAllByName(string name)
        {
            return _context.Consultants
                           .Include(e => e.User)
                           .Where(e => e.User.UserName.Contains(name.Replace(" ", ".").ToLower()));
        }
    }
}
