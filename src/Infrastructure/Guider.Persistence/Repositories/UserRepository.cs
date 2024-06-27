using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using Guider.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Guider.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly GuiderContext _context;
        public UserRepository(UserManager<User> userManager, GuiderContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<int> GetId(int userId,string role)
        {
            if (role == "Client")
            {
                var client= await _context.Clients.FirstOrDefaultAsync(e => e.UserId == userId);
                return client.Id;
            }
            else
            {
                var consultant = await _context.Consultants.FirstOrDefaultAsync(e => e.UserId == userId);
                return consultant.Id;
            }
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRolesAsync(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }


            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded)
            {
                return _context.SaveChanges() < 0;
            }
            return res.Succeeded;
        }
    }

}
