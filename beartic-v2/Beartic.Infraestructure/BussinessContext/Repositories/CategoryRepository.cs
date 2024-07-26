using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Infraestructure.BussinessContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.BussinessContext.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BussinessData _ctx;

        public CategoryRepository(BussinessData ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(Category category)
        {
            try
            {
                await _ctx.categories.AddAsync(category);
            }
            catch { }
        }

        public void Delete(Category category)
        {
            try
            {
                _ctx.categories.Remove(category);
            }
            catch { }
        }

        public async Task<Category> GetById(string id)
        {
            try
            {
                return await _ctx.categories.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch { return null; }
        }

        public async Task<Category> GetByName(string name)
        {
            try
            {
                return await _ctx.categories.FirstOrDefaultAsync(x => x.Name.ToString() == name);
            }
            catch { return null; }
        }

        public async Task Update(Category category)
        {
            try
            {
                _ctx.categories.Entry(category).State = EntityState.Modified;
                _ctx.categories.Update(category);
            }
            catch { return; }
        }
    }
}
