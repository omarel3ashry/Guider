using Guider.Domain.Common;
using Guider.Domain.Entities;
using Guider.Domain.Enums;

namespace Guider.Application.Contracts.Persistence
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public Task<Appointment?> GetWithIncludesAsync(int id);
        public IQueryable<Appointment> GetAllForUser<T>(int consultantId, int state) where T : Consumer;
        public IQueryable<IReadOnlyCollection<Appointment>> GetStatsForUser<T>(int consultantId) where T : Consumer;
        public Task<Appointment?> GetWithClientAndConsultantAsync(int id);
        public Task<Appointment?> GetWithTransactionAsync(int id);
        public Task<float> CalculateAverageRate(int CounsultantId);
        public Task UpdateAppointmentStateAsync(int appointmentId, AppointmentState newState, float? rate);
        public Task UpdateRangeAsync(IEnumerable<Appointment> appointments);
        public Task UpdateAppointmentRateAsync(int appointmentId, int rate);
    }
}