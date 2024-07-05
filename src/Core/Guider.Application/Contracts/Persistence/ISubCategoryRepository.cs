using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface ISubCategoryRepository
    {
        Task<List<Consultant>> SearchConsultantsBySubCategoryAsync(int subCategoryId, string consultantName = null);
        Task<List<SubCategory>> getbyCategoryId(int categoryId);

    }
}
