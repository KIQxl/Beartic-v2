using Beartic.Application.UseCases.CustomerUseCases;
using Beartic.Core.Interfaces;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesCustomer
{
    [TestClass]
    public class GetCustomerTest
    {
        private ICustomerRepository _customerRepository = new FakeCustomerRepository();

        [TestMethod]
        public void WhenExistsDocumentNumberInDatabaseReturnResultStatus200AndCustomerNameKaique()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var result = customerServices.GetCustomerByDocument("45261517850");

            Assert.IsTrue(result.Result.Success && result.Result.Data.Name == "Kaique Alves" && result.Result.Status == 200);
        }

        [TestMethod]
        public void WhenDontExistsDocumentNumberInDatabaseReturnResultStatus404()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var result = customerServices.GetCustomerByDocument("1");

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }
    }
}
