using Beartic.Core.UseCases.CustomerUseCases.CustomerDtos;

namespace Beartic.Core.UseCases.CustomerUseCases
{
    public interface ICustomerServices
    {
        public Task<CustomerResult> CreateCustomer(CreateCustomerDto request);
        public Task<CustomerResult> Remove(string id);
        public Task<CustomerResult> Update(UpdateCustomerDto request);
        public Task<CustomerResult> GetCustomerByDocument(string document);
        public Task<CustomerResult> GetCustomerById(string id);
        public Task<CustomersResult> GetCustomersAsync();
    }
}
