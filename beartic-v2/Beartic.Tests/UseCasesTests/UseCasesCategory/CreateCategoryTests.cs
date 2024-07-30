using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.CategoryUseCases;
using Beartic.Core.UseCases.CategoryUseCases.CategoryDtos;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesCategory
{
    [TestClass]
    public class CreateCategoryTests
    {
        private readonly ICategoryRepository _categoryRepository = new FakeCategoryRepository();

        [TestMethod]
        public void GivenValidRequestReturnResultStatus201()
        {
            var services = new CategoryServices(_categoryRepository);
            var request = new CreateCategoryDto("Category", "Category");

            var result = services.CreateAsync(request);
            Assert.IsTrue(result.Result.Success && result.Result.Status == 201);
        }

        [TestMethod]
        public void GivenInvalidRequestReturnResultStatus401()
        {
            var services = new CategoryServices(_categoryRepository);
            var request = new CreateCategoryDto("", "Category");

            var result = services.CreateAsync(request);
            Assert.IsTrue(!result.Result.Success && result.Result.Status == 401);
        }
    }
}
