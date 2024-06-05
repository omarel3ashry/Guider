using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class ConsultantRepository : BaseRepository<Consultant>, IConsultantRepository
    {
        public Task<bool> AddAsync(Consultant entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Consultant entity)
        {
            throw new NotImplementedException();
        }

        public Task<Consultant> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Consultant>> GetConsultantsWithCategory()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Consultant>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Consultant entity)
        {
            throw new NotImplementedException();
        }
    }
}
