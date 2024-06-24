using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {

        public ScheduleRepository(GuiderContext context) : base(context)
        {
        }

        public async Task<bool> AddSchedulesAsync(List<Schedule> schedules)
        {

            await _context.Schedules.AddRangeAsync(schedules);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<List<Schedule>> GetSchedulesByConsultantIdAsync(int consultantId)
        {
            return await _context.Schedules
                .Where(s => s.ConsultantId == consultantId)
                .ToListAsync();
        }
        public async Task<Schedule> GetScheduleByConsultantIdAndDateAsync(int consultantId, DateTime date)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(s => s.ConsultantId == consultantId && s.Date.Date == date.Date);
        }

        public async Task<bool> UpdateScheduleAsync(int consultantId, DateTime date, List<Schedule> updatedSchedule)
        {
            var existingSchedule = await GetScheduleByConsultantIdAndDateAsync(consultantId, date);

            if (existingSchedule == null)
            {
                return false;
            }

            // Remove the existing schedule
            _context.Schedules.Remove(existingSchedule);
            await _context.Schedules.AddRangeAsync(updatedSchedule);
            return await _context.SaveChangesAsync()>0;
        }
        public async Task DeleteAsync(Schedule entity)
        {
            _context.Schedules.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}