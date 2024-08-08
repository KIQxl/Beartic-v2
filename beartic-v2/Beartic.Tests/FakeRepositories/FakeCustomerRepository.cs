using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Core.ValueObjects;
using Beartic.Shared.Enums;
using Beartic.Shared.ValueObjects;

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

        public Task<Customer> GetByDocumentAsync(string document)
        {
            if(document == "45261517850")
                return Task.FromResult(new Customer(new Name("Kaique", "Alves"), new Phone("11977268607"), new Document("99403111097", EDocumentType.CPF), new Email("kaique@email.com.br"), new Address("Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202")));

            return Task.FromResult<Customer>(null);
    }

        public Task<Customer> GetByIdAsync(string id)
        {
            if (id == "123")
                return Task.FromResult(new Customer(new Name("Kaique", "Alves"), new Phone("11977268607"), new Document("99403111097", EDocumentType.CPF), new Email("kaique@email.com.br"), new Address("Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202")));

            return Task.FromResult<Customer>(null);
        }

        public Task<IList<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
