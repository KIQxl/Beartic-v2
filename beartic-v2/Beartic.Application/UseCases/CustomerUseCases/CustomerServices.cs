using Beartic.Application.Interfaces;
using Beartic.Application.UseCases.CustomerUseCases.CreateCustomer;
using Beartic.Application.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Core.Entities;
using Beartic.Core.ValueObjects;

namespace Beartic.Application.UseCases.CustomerUseCases
{
    public class CustomerServices : ICustomerServices
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResult> CreateCustomer(CreateCustomerDto request)
        {
            var name = new Name(request.Firstname, request.Lastname);
            var document = new Document(request.Document, request.DocumentType);
            var email = new Email(request.Email);
            var password = new Password(request.Password);

            var customer = new Customer(name, request.Phone, document, password, email);

            if (customer.Invalid)
                return new CustomerResult(401, "Não foi possível cadastrar o cliente", customer.Notifications);

            if (_customerRepository.GetByDocument(customer.Document.Number))
                return new CustomerResult(401, "Número de documento já está sendo utilizado");
            
            await _customerRepository.AddAsync(customer);

            return new CustomerResult(201, "Cliente cadastrado com sucesso", new CreateCustomerData(customer.Id.ToString(), customer.Name.ToString(), customer.Document.Number));
        }

        public GetCustomerResult GetCustomerById(string id)
        {
            throw new NotImplementedException();
        }

        public CustomerResult Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public CustomerResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
