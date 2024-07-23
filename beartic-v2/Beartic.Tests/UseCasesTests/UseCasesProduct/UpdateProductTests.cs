using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesProduct
{
    [TestClass]
    public class UpdateProductTests
    {
        private readonly IProductRepository _repository = new FakeProductRepository();

        [TestMethod]
        public void GivenValidRequestReturnResultStatus201()
        {
            var services = new ProductServices(_repository);
            var request = new UpdateProductDto("1", "Novo produto", "Novo produto", 100m, 20);
            var result = services.UpdateProduct(request);

            Assert.IsTrue(result.Result.Success && result.Result.Status == 201 && result.Result.Data.Title == "Novo produto");
        }

        [TestMethod]
        public void GivenInvalidRequestIdReturnResultStatus404NotFound()
        {
            var services = new ProductServices(_repository);
            var request = new UpdateProductDto("99", "Novo produto", "Novo produto", 100m, 20);
            var result = services.UpdateProduct(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }

        [TestMethod]
        public void GivenInvalidRequestReturnResultStatus401BadRequest()
        {
            var services = new ProductServices(_repository);
            var request = new UpdateProductDto("1", "", "No", 0m, 0);
            var result = services.UpdateProduct(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 401 && result.Result.Message == "Erro ao cadastrar produto");
        }
    }
}
