using Beartic.Core.UseCases.CategoryUseCases;
using Beartic.Core.UseCases.CategoryUseCases.CategoryDtos;
using Beartic.Infraestructure.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        private readonly IUow _uow;

        public CategoryController(ICategoryServices services, IUow uow)
        {
            _services = services;
            _uow = uow;
        }

        [HttpGet]
        [Route("categories/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var result = await _services.GetCategoryByIdAsync(id);

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
        [Route("categories")]
        public async Task<IActionResult> Create(CreateCategoryDto request)
        {
            try
            {
                var result = await _services.CreateAsync(request);

                if (result.Success)
                {
                    await _uow.BussinessCommit();
                    return Created($"v2/categories/{result.Data.Id}", result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("categories")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto request)
        {
            try
            {
                var result = await _services.UpdateAsync(request);

                if (result.Success)
                {
                    await _uow.BussinessCommit();
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
        [Route("categories/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var result = await _services.DeleteAsync(id);

                if (result.Success)
                {
                    await _uow.BussinessCommit();
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
