using Guider.Domain.Entities;
using Guider.Domain.Enums;

namespace Guider.Application.Contracts.Persistence
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public Task<Appointment?> GetWithTransactionAsync(int id);
        public Task<float> CalculateAverageRate(int CounsultantId);
        public Task UpdateAppointmentStateAsync(int appointmentId, AppointmentState newState, float? rate);
        public Task UpdateRangeAsync(IEnumerable<Appointment> appointments);
    }
}
