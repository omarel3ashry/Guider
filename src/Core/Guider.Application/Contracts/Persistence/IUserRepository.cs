using Guider.Application.Responses;
using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<bool> LoginAsync(string email, string password);
        public Task<User> GetByEmailAsync(string email);
    }
}
