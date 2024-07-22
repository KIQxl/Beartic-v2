using Beartic.Core.Entities;

namespace Beartic.Core.Interfaces
{
    public interface IProductRepository
    {
        public IList<Product> GetProductsByIdAsync(IList<string> ids);
        public Task<Product> GetProductByIdAsync(string id);
        public Task Add(Product product);
        public void Remove(Product product);
    }
}
