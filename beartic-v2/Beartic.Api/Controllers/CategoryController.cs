using Beartic.Core.UseCases.CategoryUseCases;
using Beartic.Core.UseCases.CategoryUseCases.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("categories/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _services.GetCategoryByIdAsync(id);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        [Route("categories")]
        public async Task<IActionResult> Create(CreateCategoryDto request)
        {
            var result = await _services.CreateAsync(request);

            if (result.Success)
                return Created($"v2/categories/{result.Data.Id}", result);

            return BadRequest(result);
        }

        [HttpPut]
        [Route("categories")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto request)
        {
            var result = await _services.UpdateAsync(request);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("categories/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _services.DeleteAsync(id);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
