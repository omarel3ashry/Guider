using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetAppointmentByIdAsync(int AppointmentId);

    }
}
