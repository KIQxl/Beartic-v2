using Beartic.Auth.UseCases.RoleUseCases;
using Beartic.Auth.UseCases.RoleUseCases.RoleDtos;
using Beartic.Infraestructure.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleService;
        private readonly IUow _uow;

        public RoleController(IRoleServices roleService, IUow uow)
        {
            _roleService = roleService;
            _uow = uow;
        }

        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _roleService.GetAll();

                if (result.Success)
                    return Ok(result);

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("roles/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var result = await _roleService.GetByIdAsync(id);

                if(result.Success)
                {
                    await _uow.AuthCommit();
                    return Ok(result);
                }

                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("roles")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto request)
        {
            try
            {
                var result = await _roleService.Create(request);

                if (result.Success)
                {
                    await _uow.AuthCommit();
                    return Created($"v2/roles/{result.Data.Id}", result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("roles/{id}")]
        public async Task<IActionResult> ActiveAndDeactive([FromRoute] string id)
        {
            try
            {
                var result = await _roleService.ActiveDeactive(id);

                if(result.Success)
                {
                    await _uow.AuthCommit();
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
