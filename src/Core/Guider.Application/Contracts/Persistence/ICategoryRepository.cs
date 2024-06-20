using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<List<Consultant>> SearchConsultantsByCategoryAsync(int subCategoryId, string consultantName = null);
    }
}
