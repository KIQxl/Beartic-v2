using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos;

namespace Beartic.Core.UseCases.ProductUseCases
{
    public class ProductServices : IProductServices
    {
        public readonly IProductRepository _productRepository;
        public readonly ICategoryRepository _categoryRepository;

        public ProductServices(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductResult> CreateProduct(CreateProductDto request)
        {
            var product = new Product(request.Title, request.Description, request.Price, request.QuantityOnHand);

            if (product.Invalid)
                return new ProductResult(401, "Erro no cadastro de produto", product.Notifications);

            foreach (var id in request.Categories)
            {
                var category = await _categoryRepository.GetById(id);

                if (category == null)
                    return new ProductResult(404, "Categoria não encontrada");

                product.AddCategory(category);
            }

            await _productRepository.Add(product);

            return new ProductResult(201, "Produto cadastrado!", new ProductResultData(product.Id.ToString(), product.Title, product.Description, product.Price, product.QuantityOnHand));
        }

        public async Task<ProductResult> DeleteProduct(string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
                return new ProductResult(404, "Produto não encontrado");

            _productRepository.Remove(product);

            return new ProductResult(200, "Produto removido com sucesso!", new ProductResultData(product.Id.ToString(), product.Title, product.Description, product.Price,product.QuantityOnHand));
        }

        public async Task<ProductResult> GetProduct(string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
                return new ProductResult(404, "Produto não encontrado");

            return new ProductResult(200, "Sucesso!", new ProductResultData(product.Id.ToString(), product.Title, product.Description, product.Price, product.QuantityOnHand));
        }

        public async Task<ProductResult> UpdateProduct(UpdateProductDto request)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null)
                return new ProductResult(404, "Produto nao encontrado");

            product.SetProduct(request.Title, request.Description, request.Price, request.QuantityOnHand);

            if(product.Invalid)
                return new ProductResult(401, "Erro ao cadastrar produto", product.Notifications);

            await _productRepository.Add(product);

            return new ProductResult(201, "Produto cadastrado", new ProductResultData(product.Id.ToString(), product.Title, product.Description, product.Price, product.QuantityOnHand));
        }
    }
}
