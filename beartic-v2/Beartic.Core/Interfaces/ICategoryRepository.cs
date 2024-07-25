using Beartic.Core.Entities;

namespace Beartic.Core.Interfaces
{
    public interface ICategoryRepository
    {
        public Task Add(Category category);
        public Task Update(Category category);
        public Task<Category> GetById(string id);
        public Task<Category> GetByName(string name);
        public void Delete(Category category);
    }
}
