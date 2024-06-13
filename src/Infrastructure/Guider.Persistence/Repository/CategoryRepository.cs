using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guider.Persistence.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GuiderContext context) : base(context)
        {
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                                 .Include(c => c.SubCategories)
                                 .ThenInclude(sc => sc.Consultants)
                                 .ThenInclude(c => c.User)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Consultant>> SearchConsultantsByCategoryAsync(int categoryId, string consultantName = null)
        {
            var category = await _context.Categories
                                         .Include(c => c.SubCategories)
                                         .ThenInclude(sc => sc.Consultants)
                                         .ThenInclude(c => c.User)
                                         .FirstOrDefaultAsync(c => c.Id == categoryId);


            
            var consultants = category.SubCategories?
                .SelectMany(sc => sc.Consultants)
                .Where(c => string.IsNullOrEmpty(consultantName) ||
                            (c.User.FirstName + " " + c.User.LastName).Contains(consultantName))
                .ToList();
            return consultants;
           
        }
    }
}
