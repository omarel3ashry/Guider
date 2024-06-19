using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using Guider.Persistence.Consts;
using Guider.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Persistence.Repositories
{
    public class ClientRegisterRepository : IRegisterUserRepository<Client>
    {
        private readonly UserManager<User> _userManager;
        private readonly GuiderContext _context;

        public ClientRegisterRepository(UserManager<User> userManager, GuiderContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AuthenticationResponse> RegisterAsync(User user, string password)
        {
            var createResult = await _userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
                return new AuthenticationResponse()
                {
                    Succeeded = createResult.Succeeded,
                    Errors = createResult.Errors.Select(e => e.Description).ToArray()
                };

            var roleResult = await _userManager.AddToRoleAsync(user, ConstRole.Client);
            if (!roleResult.Succeeded)
                return new AuthenticationResponse()
                {
                    Succeeded = roleResult.Succeeded,
                    Errors = roleResult.Errors.Select(e => e.Description).ToArray()
                };

            return new AuthenticationResponse() { Succeeded = roleResult.Succeeded };
        }
    }
}
