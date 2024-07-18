using Beartic.Core.Entities;

namespace Beartic.Application.Interfaces
{
    public interface ICustomerRepository
    {
        public Task AddAsync(Customer customer);
        public void Remove(Customer customer);
        public Customer Get(string id);
        public void Update(Customer customer);
        public bool GetByDocument(string document);
        public bool GetByEmail(string document);
    }
}
