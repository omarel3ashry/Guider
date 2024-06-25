using Guider.Domain.Entities;

namespace Guider.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<bool> LoginAsync(string email, string password);
        Task<User> GetByEmailAsync(string email);
        Task<bool> UpdateAsync(User user);
        Task<IList<string>> GetUserRolesAsync(User user);
    }
}
