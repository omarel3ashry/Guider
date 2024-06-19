using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        protected readonly GuiderContext _context;

        public AppointmentRepository(GuiderContext context)
        {
            
            _context = context;
        }
        public async Task<Appointment> GetAppointmentByIdAsync(int AppointmentId)
        {
            var appointment=await  _context.Appointment.Include(a=>a.Client).Include(a=>a.Consultant).FirstOrDefaultAsync(a=>a.Id==AppointmentId);
            return appointment;
        }
    }
}
