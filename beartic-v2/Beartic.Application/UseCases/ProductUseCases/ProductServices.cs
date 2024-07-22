﻿using Beartic.Application.UseCases.ProductUseCases.ProductDtos.ProductDtos;
using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Flunt.Notifications;

namespace Beartic.Application.UseCases.ProductUseCases
{
    public class ProductServices : IProductServices
    {
        public readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResult> CreateProduct(CreateProductDto request)
        {
            var product = new Product(request.Title, request.Description, request.Price, request.QuantityOnHand);

            if (product.Invalid)
                return new ProductResult(401, "Erro no cadastro de produto", product.Notifications);

            await _productRepository.Add(product);

            return new ProductResult(201, "Produto cadastrado!", new ProductResultData(product.Id.ToString(), product.Title, product.Description, product.Price, product.QuantityOnHand));
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
