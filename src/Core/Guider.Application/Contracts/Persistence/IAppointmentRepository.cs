using Guider.Domain.Entities;
using Guider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
        Task<float> CalculateAverageRate(int CounsultantId);
        Task UpdateAppointmentStateAsync(int appointmentId, AppointmentState newState,float? rate);
        Task UpdateRangeAsync(IEnumerable<Appointment> appointments);

    }
}
