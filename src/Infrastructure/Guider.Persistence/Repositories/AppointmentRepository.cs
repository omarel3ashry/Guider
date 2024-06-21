using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(GuiderContext context) : base(context)
        {

        }

        //public async Task<IQueryable<(Consultant Consultant, float AverageRate)>> GetSortedByAverageRateAsync(bool ascending)
        //{
        //    var consultants = await _context.Consultants
        //        .Include(c => c.User)
        //        .Include(c => c.SubCategory)
        //            .ThenInclude(sc => sc.Category)
        //            .Include(c=>c.Appointments)
        //        .ToListAsync();

        //    var query = consultants
        //        .Select(c => new
        //        {
        //            Consultant = c,
        //            AverageRate = c.Appointments.Any() ? c.Appointments.Average(a => a.Rate) : 0
        //        })
        //        .AsQueryable();

        //    query = ascending
        //        ? query.OrderBy(c => c.AverageRate)
        //        : query.OrderByDescending(c => c.AverageRate);

        //    return query;
        //}


        public async Task<float> CalculateAverageRate(int CounsultantId)
        {
           var Appointments = await _context.Appointment
        .Where(a => a.ConsultantId == CounsultantId)
        .ToListAsync();

            if (!Appointments.Any())
            {
                return 0; 
            }

            return Appointments.Average(a => a.Rate);
        }

        public async Task UpdateAppointmentStateAsync(int appointmentId, AppointmentState newState,float rate)
        {
            var appointment = await _context.Appointment.FindAsync(appointmentId);
            if (appointment != null)
            {
                appointment.State = newState;
                appointment.Rate = rate;
                _context.Appointment.Update(appointment);
                await _context.SaveChangesAsync();
               
            }
        }


    }
}
