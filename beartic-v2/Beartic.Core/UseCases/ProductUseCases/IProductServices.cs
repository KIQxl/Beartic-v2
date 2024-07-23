using Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos;

namespace Beartic.Core.UseCases.ProductUseCases
{
    public interface IProductServices
    {
        public Task<ProductResult> CreateProduct(CreateProductDto request);
        public Task<ProductResult> UpdateProduct(UpdateProductDto request);
        public Task<ProductResult> GetProduct(string id);
        public Task<ProductResult> DeleteProduct(string id);
    }
}
