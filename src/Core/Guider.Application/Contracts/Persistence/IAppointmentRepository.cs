using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
        Task<List<Appointment>> GetSortedByRateAsync(bool ascending);
        Task UpdateRangeAsync(IEnumerable<Appointment> appointments);
    }
}
