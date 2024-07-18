using Beartic.Application.UseCases.CustomerUseCases.CreateCustomer;
using Beartic.Application.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Core.Entities;

namespace Beartic.Application.UseCases.CustomerUseCases
{
    public interface ICustomerServices
    {
        public Task<CustomerResult> CreateCustomer(CreateCustomerDto request);
        public CustomerResult Remove(Customer customer);
        public CustomerResult Update(Customer customer);
        public GetCustomerResult GetCustomerById(string id);
    }
}
