using Beartic.Auth.Interfaces;
using Beartic.Core.Entities;
using Beartic.Infraestructure.AuthContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.AuthContext.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthData _ctx;

        public async Task Add(User user)
        {
            try
            {
                await _ctx.users.AddAsync(user);
            }
            catch { }
        }

        public async Task<bool> EmailExists(string email)
        {
            try
            {
                return await _ctx.users.AnyAsync(x => x.Email.Address.ToUpper() == email.ToUpper());
            }
            catch { return false; }
        }

        public async Task<User> GetByIdAsync(string id)
        {
            try
            {
                return await _ctx.users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch { return null; }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            try
            {
                return await _ctx.users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Username.ToUpper() == username.ToUpper());
            }
            catch { return null; }
        }

        public void Remove(User user)
        {
            try
            {
                _ctx.users.Remove(user);
            }
            catch { }
        }

        public void Update(User user)
        {
            try
            {
                _ctx.users.Entry(user).State = EntityState.Modified;
                _ctx.users.Update(user);
            }
            catch { }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await _ctx.users.AsNoTracking().ToListAsync();
            }
            catch { return null; }
        }
    }
}
