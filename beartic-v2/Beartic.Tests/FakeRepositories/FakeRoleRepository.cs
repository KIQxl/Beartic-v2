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

        public Task<IList<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetByIdAsync(string id)
        {
            if(id == "123")
                return new Role("Diretor", true);

            if (id == "1234")
                return new Role("Gerente", true);

            return null;
        }

        public Task<Role> GetByName()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
