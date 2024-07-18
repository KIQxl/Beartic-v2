using Beartic.Application.Interfaces;
using Beartic.Application.UseCases.CustomerUseCases;
using Beartic.Application.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesCustomer
{
    [TestClass]
    public class CreateCustomerTests
    {
        private ICustomerRepository _customerRepository = new FakeCustomerRepository();

        [TestMethod]
        public async void GivenValidCustomerRequest()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var customerRequest = new CreateCustomerDto("Kaique", "Alves", "11977268607", "kaique@email.com", "45261517850", Core.Enums.EDocumentType.CPF, "12345678");
            var result = await customerServices.CreateCustomer(customerRequest);

            Assert.IsTrue(result.Success && result.Status == 201);
        }
    }
}
