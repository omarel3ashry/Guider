using Guider.Application.Responses;
using Guider.Domain.Entities;


namespace Guider.Application.Contracts.Persistence
{
    public interface IRegisterUserRepository<T>
    {
        public Task<AuthenticationResponse> RegisterAsync(User user, string password);
    }
}
