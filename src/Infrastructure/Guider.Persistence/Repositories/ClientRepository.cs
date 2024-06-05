using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class ClientRepository : IRepository<Client>,IClientRepository
    {
        public Task<bool> AddAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Client>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
