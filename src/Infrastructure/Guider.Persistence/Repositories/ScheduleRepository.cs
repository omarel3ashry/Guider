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
                .Where(e => e.ConsultantId == consultantId && !e.IsReserved)
                .ToListAsync();
        }
        public async Task<Schedule> GetScheduleByConsultantIdAndDateAsync(int consultantId, DateTime date)
        {
            return await _context.Schedules.FirstOrDefaultAsync(s => s.ConsultantId == consultantId && s.Date == date);
        }

        public async Task<bool> UpdateScheduleAsync(Schedule currentSchedule, List<Schedule> newSchedules)
        {
            //var existingSchedule = await GetScheduleByConsultantIdAndDateAsync(consultantId, date);

            //if (existingSchedule == null)
            //{
            //    return false;
            //}

            // Remove the existing schedule
            _context.Schedules.Remove(currentSchedule);
            await _context.Schedules.AddRangeAsync(newSchedules);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateScheduleStateAsync(int consultantId, DateTime date, bool isReserved, int timeSpan)
        {
            var schedules = await _context.Schedules.Where(s => s.ConsultantId == consultantId).ToListAsync();
            for (int i = 0; i < timeSpan; i++)
            {
                schedules.FirstOrDefault(e => e.Date == date.AddHours(i))!.IsReserved = isReserved;
            }
            _context.Schedules.UpdateRange(schedules);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}