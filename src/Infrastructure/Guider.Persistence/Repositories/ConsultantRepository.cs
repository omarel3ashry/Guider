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
    public class ConsultantRepository : IConsultantRepository
    {
        private readonly GuiderContext _context;

        public ConsultantRepository(GuiderContext context)
        {
            _context = context;
        }

        public async Task<Consultant> GetConsultantByIdAsync(int consultantId)
        {
            return await _context.Consultants
                .Include(c => c.Schedules)
                .FirstOrDefaultAsync(c => c.Id == consultantId);
        }
    }
}
