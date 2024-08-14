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
        public static string GenerateToken(string name, string id, IEnumerable<Role> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dn3923nfc9w0hc92h90p2wh");



            var claims = new List<Claim>
            {
                new Claim("Id", id),
                new Claim(ClaimTypes.Name, name),
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
