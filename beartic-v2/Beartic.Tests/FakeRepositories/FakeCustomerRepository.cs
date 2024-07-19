using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Core.ValueObjects;

namespace Beartic.Tests.FakeRepositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Task AddAsync(Customer customer)
        {
            return Task.CompletedTask;
        }

        public Customer Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            if(document == "45261517850")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if(email == "email@email.com")
                return true;

            return false;
        }

        public void Remove(Customer customer)
        {
            return;
        }

        public void Update(Customer customer)
        {
            return;
        }

        public async Task<Customer> GetByDocumentAsync(string document)
        {
            if(document == "45261517850")
                return new Customer(new Name("Kaique", "Alves"), "11977268607", new Document("99403111097", Core.Enums.EDocumentType.CPF), new Password("123456789"), new Email("kaique@email.com.br"), new Address("Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202"));

            return null;
    }

        public async Task<Customer> GetByIdAsync(string id)
        {
            if (id == "123")
                return new Customer(new Name("Kaique", "Alves"), "11977268607", new Document("99403111097", Core.Enums.EDocumentType.CPF), new Password("123456789"), new Email("kaique@email.com.br"), new Address("Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202"));

            return null;
        }
    }
}
