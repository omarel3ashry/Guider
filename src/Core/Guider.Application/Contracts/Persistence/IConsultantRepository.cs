using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repository
{
    public interface IConsultantRepository : IRepository<Consultant>
    {
        Task<List<Consultant>> GetAllConsultantsAsync();
        Task<List<Consultant>> GetSortedByHourlyRateAsync(bool ascending);
        Task<List<Consultant>> GetConsultantsByUserNameAsync(string searchQuery);
        Task<(List<Consultant> Consultants, int TotalCount)> GetPaginatedConsultantsAsync(int page, int pageSize);


    }
}
