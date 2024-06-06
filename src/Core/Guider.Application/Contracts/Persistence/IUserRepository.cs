using Guider.Application.Responses;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        public Task<AuthenticationResponse> RegisterAsync(User user, string password);
        public Task<bool> LoginAsync(string email, string password);
        public Task<bool> UpdateAsync(User user);
        public Task<User?> GetByEmailAsync(string email);
    }
}
