using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesProduct
{
    [TestClass]
    public class GetProductTests
    {
        private readonly IProductRepository _repository = new FakeProductRepository();

        [TestMethod]
        public void GivenValidAndExistsIdReturnResultStatus200()
        {
            var services = new ProductServices(_repository);
            var result = services.GetProduct("1");

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200 && result.Result.Data.Title == "Produto 1");
        }

        [TestMethod]
        public void GivenInvalidAndNotExistsIdReturnResultStatus404()
        {
            var services = new ProductServices(_repository);
            var result = services.GetProduct("99");

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }
    }
}
