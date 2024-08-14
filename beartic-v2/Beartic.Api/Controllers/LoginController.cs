using Beartic.Api.Services;
using Beartic.Auth.UseCases.LoginUseCases;
using Beartic.Auth.UseCases.LoginUseCases.LoginDtos;
using Microsoft.AspNetCore.Mvc;

namespace Beartic.Api.Controllers
{
    [ApiController]
    [Route("v2")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(RequestLoginDto request)
        {
            try
            {
                var result = await _loginServices.Login(request);

                if (result.Success)
                {
                    var token = TokenService.GenerateToken(result.Data.Username, result.Data.Id, result.Data.roles);
                    result.Data.Token = token;

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
