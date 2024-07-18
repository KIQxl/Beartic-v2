using Beartic.Application.Interfaces;
using Beartic.Core.Entities;

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

        public bool GetByDocument(string document)
        {
            throw new NotImplementedException();
        }

        public bool GetByEmail(string document)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
