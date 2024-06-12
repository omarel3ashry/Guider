using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(GuiderContext context):base(context)
        {
            
        }
        public async  Task UpdateRangeAsync(IEnumerable<Appointment> appointments)
        {
            context.Appointment.UpdateRange(appointments);
            await context.SaveChangesAsync();
        }
    }
}
