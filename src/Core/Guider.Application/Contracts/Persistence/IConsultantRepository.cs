using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IConsultantRepository : IRepository<Consultant>
    {
        Task<List<Consultant>> GetAllConsultantsAsync();
        Task<List<Consultant>> GetSortedByHourlyRateAsync(bool ascending);
        Task<List<Consultant>> GetConsultantsByUserNameAsync(string searchQuery);
        Task<(List<Consultant> Consultants, int TotalCount)> GetPaginatedConsultantsAsync(int page, int pageSize);


    }
}
