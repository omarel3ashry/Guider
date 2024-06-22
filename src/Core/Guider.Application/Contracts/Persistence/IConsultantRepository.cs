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
        public  Task<(List<Consultant> Consultants, int TotalCount)> SearchConsultantsAsync(string searchQuery, int page, int pageSize);

        Task<(List<Consultant> Consultants, int TotalCount)> GetSortedByHourlyRateAsync(bool ascending, int page, int pageSize);
        Task<List<Consultant>> GetConsultantsByUserNameAsync(string searchQuery);
        Task<(List<Consultant> Consultants, int TotalCount)> GetPaginatedConsultantsAsync(int page, int pageSize);
        Task<IQueryable<Consultant>> GetSortedByAverageRateAsync(bool ascending);
        Task UpdateConsultantAverageRate(int consultantId);

        Task<List<Consultant>> GetConsultantsWithsubCategoryAndSchedule();
        Task<Consultant> GetConsultantWithsubCategoryAndSchedule(int id);
        Task<Consultant> GetConsultantWithUserByIdAsync(int id);
    }
}
