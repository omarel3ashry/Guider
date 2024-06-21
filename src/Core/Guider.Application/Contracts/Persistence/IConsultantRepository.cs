using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IConsultantRepository : IRepository<Consultant>
    {
        Task<List<Consultant>> GetAllConsultantsAsync();
        public  Task<(List<Consultant> Consultants, int TotalCount)> SearchConsultantsAsync(string searchQuery, int page, int pageSize);

        Task<(List<Consultant> Consultants, int TotalCount)> GetSortedByHourlyRateAsync(bool ascending, int page, int pageSize);
        Task<List<Consultant>> GetConsultantsByUserNameAsync(string searchQuery);
        Task<(List<Consultant> Consultants, int TotalCount)> GetPaginatedConsultantsAsync(int page, int pageSize);
        Task<IQueryable<Consultant>> GetSortedByAverageRateAsync(bool ascending);
        Task UpdateConsultantAverageRate(int consultantId);

    }
}
