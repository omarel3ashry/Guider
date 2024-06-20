using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IConsultantRepository : IRepository<Consultant>
    {
        Task<List<Consultant>> GetAllConsultantsAsync();
        Task<List<Consultant>> GetSortedByHourlyRateAsync(bool ascending);
        Task<List<Consultant>> GetConsultantsByUserNameAsync(string searchQuery);
        Task<(List<Consultant> Consultants, int TotalCount)> GetPaginatedConsultantsAsync(int page, int pageSize);


        Task<List<Consultant>> GetConsultantsWithsubCategoryAndSchedule();
        Task<Consultant> GetConsultantWithsubCategoryAndSchedule(int id);
        Task<Consultant> GetConsultantWithUserByIdAsync(int id);
    }
}
