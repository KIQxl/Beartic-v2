using Beartic.Application.UseCases.ProductUseCases;
using Beartic.Core.Interfaces;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesProduct
{
    [TestClass]
    public class RemoveProductTests
    {
        private readonly IProductRepository _repository = new FakeProductRepository();

        [TestMethod]
        public void GivenValidAndExistsIdReturnResultStatus200()
        {
            var services = new ProductServices(_repository);
            var result = services.DeleteProduct("1");

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }
    }
}
