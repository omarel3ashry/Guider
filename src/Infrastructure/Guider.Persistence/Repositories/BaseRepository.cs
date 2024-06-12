using Guider.Application.Contracts.Persistence;
using Guider.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly GuiderContext context;

        public BaseRepository(GuiderContext guiderContext)
        {
            context = guiderContext;
        }
        public async Task<bool> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

            public async  Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async  Task<bool> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
    

