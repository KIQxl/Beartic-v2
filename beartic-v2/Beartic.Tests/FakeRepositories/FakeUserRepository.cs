using Beartic.Auth.Interfaces;
using Beartic.Auth.ValueObjects;
using Beartic.Core.Entities;
using Beartic.Shared.Enums;
using Beartic.Shared.ValueObjects;

namespace Beartic.Tests.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        public Task Add(User user)
        {
            return Task.CompletedTask;
        }

        public async Task<bool> EmailExists(string email)
        {
            if (email == "exists@email.com")
                return true;

            return false;
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            if (id == "123")
                return new User("user", new Name("usuário", "usuário"), new Email("email@email.com"), new Document("65950707079", EDocumentType.CPF), new Phone("11977223311"), new Password("123456789"));

            return null;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            if (username == "user")
                return new User("user", new Name("usuário", "usuário"), new Email("email@email.com"), new Document("65950707079", EDocumentType.CPF), new Phone("11977223311"), new Password("123456789"));

            return null;
        }

        public void Remove(User user)
        {
            return;
        }

        public void Update(User user)
        {
            return;
        }
    }
}
