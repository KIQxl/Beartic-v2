using Beartic.Auth.Entities;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Beartic.Api.Services
{
    public static class TokenService
    {
        public static string GenerateToken(string id, string name, string email, IEnumerable<Role> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dn3923nfc9w0hc92h90p2wh");



            var claims = new List<Claim>
            {
                new Claim("Id", id),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email)
            };

            foreach (var role in roles)
            {
                
                claims.Add(new Claim(ClaimTypes.Role, role.Name));

            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
