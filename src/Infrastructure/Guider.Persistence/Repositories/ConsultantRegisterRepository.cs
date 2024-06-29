using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using Guider.Persistence.Consts;
using Microsoft.AspNetCore.Identity;

namespace Guider.Persistence.Repositories
{
    public class ConsultantRegisterRepository : IRegisterUserRepository<Consultant>
    {
        private readonly UserManager<User> _userManager;

        public ConsultantRegisterRepository(UserManager<User> userManager)
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

            var roleResult = await _userManager.AddToRoleAsync(user, ConstRole.Consultant);
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
