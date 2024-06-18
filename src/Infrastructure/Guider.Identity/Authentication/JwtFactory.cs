using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Guider.Identity.Authentication
{
    public class JwtFactory
    {
        private readonly IConfiguration _config;

        public JwtFactory(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwt(int userId, string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // this key ideally should be saved in more secure place 
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, email),
                new(PolicyData.IdClaimName, userId.ToString()),
                new(JwtRegisteredClaimNames.Email, email),
                new(PolicyData.RoleClaimName, role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // TODO: change exp date
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
