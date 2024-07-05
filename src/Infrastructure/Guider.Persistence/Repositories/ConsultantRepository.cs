using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class ConsultantRepository : BaseRepository<Consultant>, IConsultantRepository
    {
        public ConsultantRepository(GuiderContext context) : base(context) { }

        public async Task<Consultant?> GetWithUserAsync(int consultantId)
        {
            return await _context.Consultants.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == consultantId);
        }

        public async Task<Consultant?> GetWithIncludesAsync(int id)
        {
            return await _context.Consultants
                                 .Include(e => e.User)
                                 .Include(e => e.SubCategory)
                                 .Include(e => e.Schedules)
                                 .FirstOrDefaultAsync(e => e.Id == id);
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

        public async Task<List<Consultant>> GetUnVerifiedConsultants()
        {
            return await _context.Consultants.Where(e => !e.IsVerified)
                .Include(e => e.User)
                .Include(e => e.SubCategory)
                .ToListAsync();
        }

        public async Task<Consultant?> GetConsultantWithsubCategoryUserAndAttachmentsById(int id)
        {
            return await _context.Consultants
               .Include(c => c.User)
               .Include(e => e.SubCategory)
               .Include(e => e.Attachments)
               .FirstOrDefaultAsync(c => c.Id == id && !c.User.IsDeleted);
        }
    }
}
