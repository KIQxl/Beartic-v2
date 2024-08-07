using Beartic.Core.UseCases.OrderUseCases;
using Beartic.Core.UseCases.OrderUseCases.OrderDtos;
using Beartic.Infraestructure.BussinessContext.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _services;
        private readonly IUow _uow;

        public OrderController(IOrderServices services, IUow uow)
        {
            _services = services;
            _uow = uow;
        }

        [HttpPost]
        [Route("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto request)
        {
            try
            {
                var result = await _services.CreateOrder(request);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Created($"v2/orders/{result.Data.Id}", result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<IActionResult> GetOrderByIdAsync([FromRoute] string id)
        {
            try
            {
                var result = await _services.GetOrderByIdAsync(id);

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
        [Route("orders/pay")]
        public async Task<IActionResult> PayOrder([FromBody] PayOrderDto payRequest)
        {
            try
            {
                var result = await _services.PayOrderAsync(payRequest);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
