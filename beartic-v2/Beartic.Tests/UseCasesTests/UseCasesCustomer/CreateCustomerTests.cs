using Beartic.Application.UseCases.CustomerUseCases;
using Beartic.Application.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Core.Interfaces;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesCustomer
{
    [TestClass]
    public class CreateCustomerTests
    {
        private ICustomerRepository _customerRepository = new FakeCustomerRepository();

        [TestMethod]
        public void GivenValidCustomerRequestReturnStatusResult201AndResultSuccessTrue()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var customerRequest = new CreateCustomerDto("Kaique", "Alves", "11977268607", "kaique@email.com", "58331602005", Core.Enums.EDocumentType.CPF, "12345678", "Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202");
            var result = customerServices.CreateCustomer(customerRequest);

            Assert.IsTrue(result.Result.Status == 201 && result.Result.Success);
        }

        [TestMethod]
        public void GivenCustomerDocumentNumberRequestExistsInDatabaseStatusResult401AndResultSuccessFalse()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var customerRequest = new CreateCustomerDto("Kaique", "Alves", "11977268607", "kaique@email.com", "45261517850", Core.Enums.EDocumentType.CPF, "12345678", "Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202");
            var result = customerServices.CreateCustomer(customerRequest);

            Assert.IsTrue(result.Result.Status == 401 && !result.Result.Success && result.Result.Message == "Número de documento já está sendo utilizado");
        }

        [TestMethod]
        public void GivenInvalidCustomerRequestStatusResult401AndResultSuccessFalse()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var customerRequest = new CreateCustomerDto("", "Als", "11978607", "kaiquemail.com", "", Core.Enums.EDocumentType.CPF, "12345678", "Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202");
            var result = customerServices.CreateCustomer(customerRequest);

            Assert.IsTrue(result.Result.Status == 401 && !result.Result.Success && result.Result.Message == "Não foi possível cadastrar o cliente" && result.Result.Errors.Any());
        }
    }
}
