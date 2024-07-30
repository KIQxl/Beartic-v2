using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("products/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var result = await _services.GetProduct(id);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto request)
        {
            var result = await _services.CreateProduct(request);

            if(result.Success )
                return Created($"v2/products/{result.Data.Id}", result);

            return BadRequest(result);
        }

        [HttpPut]
        [Route("products")]
        public async Task<IActionResult> Update(UpdateProductDto request)
        {
            var result = await _services.UpdateProduct(request);

            if(result.Success )
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("products/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _services.DeleteProduct(id);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
