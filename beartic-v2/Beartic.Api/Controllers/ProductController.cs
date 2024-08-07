using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos;
using Beartic.Infraestructure.BussinessContext.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        private readonly IUow _uow;

        public ProductController(IProductServices services, IUow uow)
        {
            _services = services;
            _uow = uow;
        }

        [HttpGet]
        [Route("products/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            try
            {
                var result = await _services.GetProduct(id);

                if (result.Success)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto request)
        {
            try
            {
                var result = await _services.CreateProduct(request);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Created($"v2/products/{result.Data.Id}", result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("products")]
        public async Task<IActionResult> Update(UpdateProductDto request)
        {
            try
            {
                var result = await _services.UpdateProduct(request);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("products/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var result = await _services.DeleteProduct(id);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
