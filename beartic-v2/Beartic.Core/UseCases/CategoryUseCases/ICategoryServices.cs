using Beartic.Core.UseCases.CategoryUseCases.CategoryDtos;

namespace Beartic.Core.UseCases.CategoryUseCases
{
    public interface ICategoryServices
    {
        public Task<CategoryResult> GetCategoryByIdAsync(string id);
        public Task<CategoryResult> CreateAsync(CreateCategoryDto request);
        public Task<CategoryResult> UpdateAsync(CreateCategoryDto request);
        public Task<CategoryResult> DeleteAsync(string id);
    }
}
