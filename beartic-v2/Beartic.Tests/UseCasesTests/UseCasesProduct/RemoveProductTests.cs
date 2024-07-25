using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesProduct
{
    [TestClass]
    public class RemoveProductTests
    {
        private readonly IProductRepository _repository = new FakeProductRepository();
        private readonly ICategoryRepository _categoryRepository = new FakeCategoryRepository();

        [TestMethod]
        public void GivenValidAndExistsIdReturnResultStatus200()
        {
            var services = new ProductServices(_repository, _categoryRepository);
            var result = services.DeleteProduct("1");

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }
    }
}
