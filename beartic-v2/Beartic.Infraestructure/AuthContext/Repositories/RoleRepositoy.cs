using Beartic.Auth.Entities;
using Beartic.Auth.Interfaces;
using Beartic.Infraestructure.AuthContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.AuthContext.Repositories
{
    public class RoleRepositoy : IRoleRepository
    {
        private readonly AuthData _ctx;

        public async Task Add(Role role)
        {
            try
            {
                await _ctx.roles.AddAsync(role);
            }
            catch { }
        }

        public async Task<Role> GetByIdAsync(string id)
        {
            try
            {
                return await _ctx.roles.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch { return null; }
        }
    }
}
