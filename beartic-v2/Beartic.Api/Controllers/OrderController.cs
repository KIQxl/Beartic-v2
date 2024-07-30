using Beartic.Core.UseCases.OrderUseCases;
using Beartic.Core.UseCases.OrderUseCases.OrderDtos;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _services;

        public OrderController(IOrderServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto request)
        {
            var result = await _services.CreateOrder(request);

            if(result.Success)
                return Created($"v2/orders/{result.Data.Id}", result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<IActionResult> GetOrderByIdAsync([FromRoute] string id)
        {
            var result = await _services.GetOrderByIdAsync(id);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }
    }
}
