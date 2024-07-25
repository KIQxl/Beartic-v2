using Beartic.Auth.Entities;
using Beartic.Auth.Interfaces;

namespace Beartic.Tests.FakeRepositories
{
    public class FakeRoleRepository : IRoleRepository
    {
        public Task Add(Role role)
        {
            return Task.CompletedTask;
        }

        public async Task<Role> GetByIdAsync(string id)
        {
            if(id == "123")
                return new Role("Diretor", true);

            if (id == "1234")
                return new Role("Gerente", true);

            return null;
        }
    }
}
