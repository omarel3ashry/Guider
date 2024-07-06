using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GuiderContext context) : base(context)
        {
        }

        public Task<Category?> GetWithSubCategoriesAsync(int id)
        {
            return _context.Categories
                           .Include(e => e.SubCategories)
                           .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Category>> GetAllWithSubCategories()
        {
            return await _context.Categories.Include(c => c.SubCategories).ToListAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
