using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IConsultantRepository : IRepository<Consultant>
    {
        Task<List<Consultant>> GetAllConsultantsAsync();
        public Task<(List<Consultant> Consultants, int TotalCount)> SearchConsultantsAsync(string searchQuery, int page, int pageSize);

        Task<(List<Consultant> Consultants, int TotalCount)> GetSortedByHourlyRateAsync(bool ascending, int page, int pageSize);
        Task<List<Consultant>> GetConsultantsByUserNameAsync(string searchQuery);
        Task<(List<Consultant> Consultants, int TotalCount)> GetPaginatedConsultantsAsync(int page, int pageSize);
        Task<IQueryable<Consultant>> GetSortedByAverageRateAsync(bool ascending);
        Task<IQueryable<Consultant>> GetSubCategorySortedByAverageRateAsync(bool ascending,int subcategoryId);
        Task<IQueryable<Consultant>> GetSubCategorySortedByHourlyRateAsync(bool ascending, int subcategoryId);

        Task UpdateConsultantAverageRate(int consultantId);

        Task<List<Consultant>> GetConsultantsWithsubCategoryAndSchedule();
        Task<Consultant> GetConsultantWithsubCategoryAndSchedule(int id);
        Task<Consultant> GetConsultantWithUserByIdAsync(int id);
        Task<IQueryable<Consultant>> getConsultantsbyCategoryId(int categoryId);
        Task<IQueryable<Consultant>> getConsultantsbySubCategoryId(int subcategoryId);
    }
}
