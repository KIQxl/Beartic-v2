using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesProduct
{
    [TestClass]
    public class CreateProductTests
    {
        private readonly IProductRepository _repository = new FakeProductRepository();
        private readonly ICategoryRepository _categoryRepository = new FakeCategoryRepository();

        [TestMethod]
        public void GivenValidRequestReturnResultStatus201()
        {
            var services = new ProductServices(_repository, _categoryRepository);
            var request = new CreateProductDto("Produto teste", "Produto criado para testes", 1000m, 100, new List<string> { "123" });
            var result = services.CreateProduct(request);

            Assert.IsTrue(result.Result.Success && result.Result.Status == 201);
        }

        [TestMethod]
        public void GivenInvalidRequestReturnResultStatus400() 
        {
            var services = new ProductServices(_repository, _categoryRepository);
            var request = new CreateProductDto("P", "Produto criado par", -1, -10, new List<string> { "123" });
            var result = services.CreateProduct(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 400 && result.Result.Errors.Any());
        }
    }
}
