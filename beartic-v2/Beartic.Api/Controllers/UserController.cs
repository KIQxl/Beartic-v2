using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;
using Beartic.Infraestructure.BussinessContext.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IUow _uow;

        public UserController(IUserServices userServices, IUow uow)
        {
            _userServices = userServices;
            _uow = uow;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userServices.GetAll();

                if (result.Status == 200)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("users/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var result = await _userServices.GetById(id);

                if (result.Status == 200)
                    return Ok(result);

                return NotFound(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            try
            {
                var result = await _userServices.Create(request);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Created($"v2/users/{result.Data.Id}", result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("users")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto request)
        {
            try
            {
                var result = await _userServices.Update(request);
                if (result.Success)
                {
                    await _uow.Commit();
                    return Created($"v2/users/{result.Data.Id}", result);
                }

                if(result.Status == 400)
                return NotFound(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("users/{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id)
        {
            try
            {
                var result = await _userServices.Remove(id);

                if (result.Success)
                {
                    await _uow.Commit();
                    return Ok(result);
                }

                return NotFound(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("users/add-role")]
        public async Task<IActionResult> AddRole([FromBody] AlterRole request)
        {
            try
            {
                var result = await _userServices.AddRole(request);

                if(result.Success)
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

        [HttpPut]
        [Route("users/remove-role")]
        public async Task<IActionResult> RemoveRole([FromBody] AlterRole request)
        {
            try
            {
                var result = await _userServices.RemoveRole(request);

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
