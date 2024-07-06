using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IConsultantRepository : IRepository<Consultant>
    {
        Task<Consultant?> GetWithUserAsync(int id);
        Task<Consultant?> GetWithIncludesAsync(int id);
        Task<List<Consultant>> GetAllConsultantsAsync();
        Task UpdateConsultantAverageRate(int id);
        Task<List<Consultant>> GetTopConsultantsByAverageRateAsync();
        IQueryable<Consultant> GetAllByFilters(int categoryId, int subCategoryId, bool sortByPrice, bool sortAsc);
        IQueryable<Consultant> GetAllByName(string name);
        Task<List<Consultant>> GetUnVerifiedConsultants();
        Task<Consultant?> GetConsultantWithsubCategoryUserAndAttachmentsById(int id);
    }
}
