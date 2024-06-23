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

        public async Task<Appointment> Addappointment(Appointment appointment)
        {
            var result = await _context.Appointment.AddAsync(appointment); 
            await _context.SaveChangesAsync();
            return result.Entity;

        }

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

        public async Task UpdateAppointmentStateAsync(int appointmentId, AppointmentState newState,float? rate)
        {
            var appointment = await _context.Appointment.FindAsync(appointmentId);
            if (appointment != null)
            {
                appointment.State = newState;
                if (newState == AppointmentState.Completed && rate.HasValue)
                {
                    appointment.Rate = rate.Value;
                }
                _context.Appointment.Update(appointment);
                await _context.SaveChangesAsync();
               
            }
        }



        public async Task UpdateRangeAsync(IEnumerable<Appointment> appointments)
        {
            _context.Appointment.UpdateRange(appointments);
            await _context.SaveChangesAsync();
        }
    }
}
