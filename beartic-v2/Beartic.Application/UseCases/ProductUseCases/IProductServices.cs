using Beartic.Application.UseCases.ProductUseCases.ProductDtos.ProductDtos;

namespace Beartic.Application.UseCases.ProductUseCases
{
    public interface IProductServices
    {
        public Task<ProductResult> CreateProduct(CreateProductDto request);
        public Task<ProductResult> UpdateProduct(UpdateProductDto request);

    }
}
