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
    public class ConsultantRepository : BaseRepository<Consultant>, IConsultantRepository
    {
        public ConsultantRepository(GuiderContext context):base(context)
        {
            
        }
        
        public async Task<List<Consultant>> GetConsultantsWithsubCategoryAndSchedule()
        {
            return await context.Consultants
               .Include(e => e.SubCategory)
               .ThenInclude(e => e.Category)
               .Include(e=>e.User)
               .Include(e=>e.Schedules)
               .Where(c => !c.User.IsDeleted)
               .ToListAsync();
        }
        public  async Task<Consultant> GetConsultantWithsubCategoryAndSchedule(int id)
        {
            return await context.Consultants
               .Include(e => e.SubCategory)
               .ThenInclude(e => e.Category)
               .Include(e => e.User)
               .Include(e => e.Schedules)
               .FirstOrDefaultAsync(e => e.Id == id&& !e.User.IsDeleted);
        }
        public async Task<Consultant> GetConsultantWithUserByIdAsync(int id)
        {
            return await context.Consultants
                .Include(c => c.User)
                .Include(e=>e.Appointments)
                .FirstOrDefaultAsync(c => c.Id == id && !c.User.IsDeleted);
        }


    }
}
