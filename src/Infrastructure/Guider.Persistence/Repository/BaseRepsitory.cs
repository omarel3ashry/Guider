using Guider.Application.Contracts.Persistence;
using Guider.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly GuiderContext _context;
        public BaseRepository(GuiderContext context)
        {
            _context = context;
        }
        public Task<bool> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(T entity)
        {

            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
