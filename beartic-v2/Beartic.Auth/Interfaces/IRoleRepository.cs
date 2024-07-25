using Beartic.Auth.Entities;

namespace Beartic.Auth.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> GetByIdAsync(string id);
        public Task Add(Role role);
    }
}
