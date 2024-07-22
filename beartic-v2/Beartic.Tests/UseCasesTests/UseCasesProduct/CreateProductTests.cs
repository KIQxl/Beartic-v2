using Beartic.Application.UseCases.ProductUseCases;
using Beartic.Application.UseCases.ProductUseCases.ProductDtos.ProductDtos;
using Beartic.Core.Interfaces;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesProduct
{
    [TestClass]
    public class CreateProductTests
    {
        private readonly IProductRepository _repository = new FakeProductRepository();

        [TestMethod]
        public void GivenValidRequestReturnResultStatus201()
        {
            var services = new ProductServices(_repository);
            var request = new CreateProductDto("Produto teste", "Produto criado para testes", 1000m, 100);
            var result = services.CreateProduct(request);

            Assert.IsTrue(result.Result.Success && result.Result.Status == 201);
        }

        [TestMethod]
        public void GivenInvalidRequestReturnResultStatus401() 
        {
            var services = new ProductServices(_repository);
            var request = new CreateProductDto("P", "Produto criado par", -1, -10);
            var result = services.CreateProduct(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 401 && result.Result.Errors.Any());
        }
    }
}
