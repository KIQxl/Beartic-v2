using Beartic.Core.Entities;
using Beartic.Core.Interfaces;

namespace Beartic.Tests.FakeRepositories
{
    public class FakeProductRepository : IProductRepository
    {
        public async Task<Product> GetProductByIdAsync(string id)
        {
            if (id == "1")
                return new Product("Produto 1", "Produto 1", 100m, 50);

            if (id == "2")
                return new Product("Produto 2", "Produto 2", 200m, 50);

            if (id == "3")
                return new Product("Produto 3", "Produto 3", 300m, 50);

            if (id == "4")
                return new Product("Produto 4", "Produto 4", 400m, 50);

            if (id == "5")
                return new Product("Produto 5", "Produto 5", 500m, 50);

            return null;
        }

        public IList<Product> GetProductsByIdAsync(IList<string> ids)
        {
            throw new NotImplementedException();
        }
    }
}
