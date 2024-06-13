using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repository
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(GuiderContext context) : base(context)
        {
        }

        public async Task<List<Consultant>> SearchConsultantsBySubCategoryAsync(int subCategoryId, string consultantName = null)
        {
            var query = _context.Consultants
                                .Include(c => c.User)
                                .Include(c => c.SubCategory)
                                    .ThenInclude(sc => sc.Category)
                                .Include(c => c.Appointments) 
                                .Where(c => c.SubCategoryId == subCategoryId);

            if (!string.IsNullOrEmpty(consultantName))
            {
                query = query.Where(c => (c.User.FirstName + " " + c.User.LastName).Contains(consultantName));
            }

            return await query.ToListAsync();
        }
    }
}
