using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Shared.ValueObjects;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.CustomerUseCases
{
    public class CustomerServices : Notifiable, ICustomerServices
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResult> CreateCustomer(CreateCustomerDto request)
        {
            var name = new Name(request.Firstname, request.Lastname);
            var phone = new Phone(request.Phone);
            var document = new Document(request.Document, request.DocumentType);
            var email = new Email(request.Email);
            var address = new Address(request.Street, request.City, request.State, request.ZipCode, request.Country, request.Number);
            var customer = new Customer(name, phone, document, email, address);

            if (customer.Invalid)
                return new CustomerResult(401, "Não foi possível cadastrar o cliente", customer.Notifications);

            if (_customerRepository.DocumentExists(customer.Document.Number))
                return new CustomerResult(401, "Número de documento já está sendo utilizado");
            
            await _customerRepository.AddAsync(customer);

            return new CustomerResult(201, "Cliente cadastrado com sucesso", new CreateCustomerData(customer.Id.ToString(), customer.Name.ToString(), customer.Document.Number));
        }

        public async Task<GetCustomerResult> GetCustomerByDocument(string document)
        {
            var customer = await _customerRepository.GetByDocumentAsync(document);
            if (customer == null) 
                return new GetCustomerResult(404, "Cliente não encontrado");

            return new GetCustomerResult(200, "Sucesso", new GetCustomerData(customer.Id.ToString(), customer.Name.ToString(), customer.Document.Number, customer.Phone.Number, customer.Email.Address, customer.Address.City, customer.Address.ZipCode, customer.Address.Street, customer.Address.Number));
        }

        public async Task<GetCustomerResult> GetCustomerById(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return new GetCustomerResult(404, "Cliente não encontrado");

            return new GetCustomerResult(200, "Sucesso", new GetCustomerData(customer.Id.ToString(), customer.Name.ToString(), customer.Document.Number, customer.Phone.Number, customer.Email.Address, customer.Address.City, customer.Address.ZipCode, customer.Address.Street, customer.Address.Number));
        }

        public async Task<CustomerResult> Remove(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return new CustomerResult(404, "Cliente não encontrado");

            _customerRepository.Remove(customer);

            return new CustomerResult(200, "Cliente excluído com sucesso", new CreateCustomerData(customer.Id.ToString(), customer.Name.ToString(), customer.Document.Number));
        }

        public async Task<CustomerResult> Update(UpdateCustomerDto request)
        {
            var name = new Name(request.FirstName, request.LastName);
            var phone = new Phone(request.Phone);
            var email = new Email(request.Email);
            var document = new Document(request.Document, request.DocumentType);
            var address = new Address(request.Street, request.City, request.State, request.ZipCode, request.Country, request.Number);

            AddNotifications(name, phone, email, document, address);
            if (Invalid)
                return new CustomerResult(401, "Não foi possível alterar os dados", Notifications);

            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                return new CustomerResult(404, "Não foi possível encontrar o cliente");

            customer.ChangeName(name);
            customer.ChangePhone(phone);
            customer.ChangeEmail(email);
            customer.ChangeAddress(address);
            customer.ChangeDocument(document);

            _customerRepository.Update(customer);

            return new CustomerResult(201, "Dados do cliente alterados com sucesso", new CreateCustomerData(customer.Id.ToString(), customer.Name.ToString(), customer.Document.Number));
        }
    }
}
