using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllWithSubCategories();
        Task<List<Consultant>> SearchConsultantsByCategoryAsync(int subCategoryId, string consultantName = null);
    }
}
