using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Infraestructure.BussinessContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.BussinessContext.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BussinessData _ctx;

        public ProductRepository(BussinessData dataContext)
        {
            _ctx = dataContext;
        }

        public async Task Add(Product product)
        {
            try
            {
                await _ctx.products.AddAsync(product);
            }

            catch (Exception ex)
            {
                return;
            }
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            try
            {
                return await _ctx.products.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<Product>> GetProductsByIdAsync(IList<string> ids)
        {
            try
            {
                return await _ctx.products.Where(x => ids.Contains(x.Id.ToString())).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Remove(Product product)
        {
            try
            {
                _ctx.products.Remove(product);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
