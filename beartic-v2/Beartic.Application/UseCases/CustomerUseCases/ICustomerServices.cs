using Beartic.Application.UseCases.CustomerUseCases.CreateCustomer;
using Beartic.Application.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Core.Entities;

namespace Beartic.Application.UseCases.CustomerUseCases
{
    public interface ICustomerServices
    {
        public Task<CustomerResult> CreateCustomer(CreateCustomerDto request);
        public Task<CustomerResult> Remove(string id);
        public Task<CustomerResult> Update(UpdateCustomerDto request);
        public Task<GetCustomerResult> GetCustomerByDocument(string document);
    }
}
