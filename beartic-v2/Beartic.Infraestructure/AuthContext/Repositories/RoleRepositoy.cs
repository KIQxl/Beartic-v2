using Beartic.Auth.Entities;
using Beartic.Auth.Interfaces;
using Beartic.Infraestructure.AuthContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.AuthContext.Repositories
{
    public class RoleRepositoy : IRoleRepository
    {
        private readonly AuthData _ctx;

        public RoleRepositoy(AuthData ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(Role role)
        {
            try
            {
                await _ctx.roles.AddAsync(role);
            }
            catch { }
        }

        public async Task<IList<Role>> GetAll()
        {
            return await _ctx.roles.AsNoTracking().Where(x => x.Active == true).ToListAsync();
        }

        public async Task<Role> GetByIdAsync(string id)
        {
            try
            {
                return await _ctx.roles.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch { return null; }
        }

        public async Task<bool> GetByName(string name)
        {
            return await _ctx.roles.AsNoTracking().AnyAsync(x => x.Name.ToUpper() == name.ToUpper());
        }

        public async Task<Role> GetRoleByName(string name)
        {
            return await _ctx.roles.FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());
        }

        public void Update(Role role)
        {
            _ctx.roles.Entry(role).State = EntityState.Modified;
            _ctx.roles.Update(role);
        }
    }
}
