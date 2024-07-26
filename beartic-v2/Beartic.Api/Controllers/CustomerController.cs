using Beartic.Core.UseCases.CustomerUseCases;
using Beartic.Core.UseCases.CustomerUseCases.CustomerDtos;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;

        public CustomerController(ICustomerServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id) 
        {
            var result = await _services.GetCustomerById(id);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("customers/")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerDto request)
        {
            var result = await _services.CreateCustomer(request);

            if (result.Success)
                return Created($"v2/customers/{result.Data.Id}", result);

            return BadRequest(result);
        }

        [HttpPut]
        [Route("customers/")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto request)
        {
            var result = await _services.Update(request);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
