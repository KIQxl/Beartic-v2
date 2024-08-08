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

                if (result.Status == 400)
                    return BadRequest(result);

                return NotFound(result);
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

        [HttpPut]
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

                if (result.Status == 400)
                    return BadRequest(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("orders/parcel")]
        public async Task<IActionResult> ParcelOrder([FromBody] ParcelOrderDto parcelRequest)
        {
            try
            {
                var result = await _services.ParcelOrderAsync(parcelRequest);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Ok(result);
                }

                if (result.Status == 400)
                    return BadRequest(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var result = await _services.ListOrdersAsync();

                if (result.Success)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("orders/cancel/{id}")]
        public async Task<IActionResult> CancelOrder([FromRoute] string id)
        {
            try
            {
                var result = await _services.CancelOrderAsync(id);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Ok(result);
                }

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
