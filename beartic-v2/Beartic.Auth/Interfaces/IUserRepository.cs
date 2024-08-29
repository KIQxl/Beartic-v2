using Beartic.Core.Entities;

namespace Beartic.Auth.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task Add(User user);
        public void Update(User user);
        public Task<User> GetByIdAsync(string id);
        public Task<User> GetByUsernameAsync(string username);
        public Task<User> GetByEmailAsync(string email);
        public Task<bool> EmailExists(string email);
        public void Remove(User user);
    }
}
