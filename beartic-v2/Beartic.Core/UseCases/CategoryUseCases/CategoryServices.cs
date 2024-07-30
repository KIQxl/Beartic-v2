using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.CategoryUseCases.CategoryDtos;

namespace Beartic.Core.UseCases.CategoryUseCases
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResult> CreateAsync(CreateCategoryDto request)
        {
            var category = new Category(request.CategoryName, request.CategoryDescription);

            if (category.Invalid)
                return new CategoryResult(401, "Categoria não cadastrada", category.Notifications);

            await _categoryRepository.Add(category);

            return new CategoryResult(201, "Categoria cadastrada", new CategoryResultData(category.Id.ToString(), category.Name));
        }

        public async Task<CategoryResult> DeleteAsync(string id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null)
                return new CategoryResult(404, "Categoria não encontrada");

            _categoryRepository.Delete(category);

            return new CategoryResult(200, "Categoria removida", new CategoryResultData(category.Id.ToString(), category.Name));
        }

        public async Task<CategoryResult> GetCategoryByIdAsync(string id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null)
                return new CategoryResult(404, "Categoria não encontrada");

            return new CategoryResult(200, "Sucesso", new CategoryResultData(category.Id.ToString(), category.Name));
        }

        public async Task<CategoryResult> UpdateAsync(UpdateCategoryDto request)
        {
            var category = await _categoryRepository.GetById(request.Id);

            if (category == null)
                return new CategoryResult(404, "Categoria não encontrada");

            category.ChangeCategory(request.CategoryName, request.CategoryDescription);
            await _categoryRepository.Update(category);

            return new CategoryResult(200, "Categoria atualizada", new CategoryResultData(category.Id.ToString(), category.Name));
        }
    }
}
