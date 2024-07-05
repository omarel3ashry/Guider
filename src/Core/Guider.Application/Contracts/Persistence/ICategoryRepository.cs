using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetWithSubCategoriesAsync(int id);
        Task<List<Category>> GetAllWithSubCategories();
    }
}
