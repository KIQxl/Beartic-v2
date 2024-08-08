using Beartic.Core.Entities;

namespace Beartic.Core.Interfaces
{
    public interface ICustomerRepository
    {
        public Task AddAsync(Customer customer);
        public void Remove(Customer customer);
        public Task<Customer> GetByIdAsync(string id);
        public void Update(Customer customer);
        public bool DocumentExists(string document);
        public bool EmailExists(string document);
        public Task<Customer> GetByDocumentAsync(string document);
        public Task<IList<Customer>> GetAllAsync();
    }
}
