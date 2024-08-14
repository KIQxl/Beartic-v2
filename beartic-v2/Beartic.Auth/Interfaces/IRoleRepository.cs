using Beartic.Auth.Entities;

namespace Beartic.Auth.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> GetByIdAsync(string id);
        public Task Add(Role role);
        public Task<IList<Role>> GetAll();
        public Task<bool> GetByName(string name);
        public void Update(Role role);
    }
}
