using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using Guider.Persistence.Consts;
using Microsoft.AspNetCore.Identity;

namespace Guider.Persistence.Repositories
{
    public class ClientRegisterRepository : IRegisterUserRepository<Client>
    {
        private readonly UserManager<User> _userManager;

        public ClientRegisterRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthenticationResponse> RegisterAsync(User user, string password)
        {
            var createResult = await _userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
                return new AuthenticationResponse()
                {
                    Success = createResult.Succeeded,
                    Errors = createResult.Errors.Select(e => e.Description).ToArray()
                };

            var roleResult = await _userManager.AddToRoleAsync(user, ConstRole.Client);
            if (!roleResult.Succeeded)
                return new AuthenticationResponse()
                {
                    Success = roleResult.Succeeded,
                    Errors = roleResult.Errors.Select(e => e.Description).ToArray()
                };

            return new AuthenticationResponse() { Success = roleResult.Succeeded, Id = user.Id };
        }
    }
}
