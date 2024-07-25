using Beartic.Core.Entities;
using Beartic.Core.Interfaces;

namespace Beartic.Tests.FakeRepositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        public Task Add(Category category)
        {
            return Task.CompletedTask;
        }

        public void Delete(Category category)
        {
            return;
        }

        public async Task<Category> GetById(string id)
        {
            if (id == "123")
                return new Category("Categoria", "Categoria de testes");

            return null;
        }

        public async Task<Category> GetByName(string name)
        {
            if (name == "categoria teste")
                return new Category("categoria teste", "descrição categoria");

            return null;
        }

        public Task Update(Category category)
        {
            return Task.CompletedTask;
        }
    }
}
