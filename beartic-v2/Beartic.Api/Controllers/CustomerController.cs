using Beartic.Core.UseCases.CustomerUseCases;
using Beartic.Core.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Infraestructure.BussinessContext.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;
        private readonly IUow _uow;

        public CustomerController(ICustomerServices services, IUow uow)
        {
            _services = services;
            _uow = uow;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id) 
        {
            try
            {
                var result = await _services.GetCustomerById(id);

                if (result.Success)
                    return Ok(result);


                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("customers/get-by-document/{document}")]
        public async Task<IActionResult> GetByDocumentAsync([FromRoute] string document)
        {
            try
            {
                var result = await _services.GetCustomerByDocument(document);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("customers/")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerDto request)
        {
            try
            {
                var result = await _services.CreateCustomer(request);

                if (result.Success)
                {
                    _uow.Commit();
                    return Created($"v2/customers/{result.Data.Id}", result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("customers/")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto request)
        {
            try
            {
                var result = await _services.Update(request);

                if (result.Success)
                {
                    _uow.Commit();
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch(Exception ex)
            {
                _uow.Rollback();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id)
        {
            try
            {
                var result = await _services.Remove(id);

                if (result.Success)
                {
                    _uow.Commit();
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return StatusCode(500, ex.Message);
            }
        }
    }
}
