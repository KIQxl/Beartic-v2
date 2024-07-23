using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.CustomerUseCases;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesCustomer
{
    [TestClass]
    public class RemoveCustomerTests
    {
        private ICustomerRepository _customerRepository = new FakeCustomerRepository();

        [TestMethod]
        public void GivenExistsIdInDatabaseReturnStatusResult200ResultSuccessTrue()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var result = customerServices.Remove("123");

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }

        [TestMethod]
        public void GivenDontExistsIdInDatabaseReturnStatusResult404ResultSuccessFalse()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var result = customerServices.Remove("1");

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }
    }
}
