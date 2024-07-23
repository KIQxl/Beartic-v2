using Beartic.Core.Entities;

namespace Beartic.Auth.Interfaces
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task<User> GetByIdAsync(string id);
        public Task<User> GetByUsernameAsync(string username);
    }
}
