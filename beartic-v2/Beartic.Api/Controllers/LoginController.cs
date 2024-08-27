using Beartic.Api.Services;
using Beartic.Auth.Entities;
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
        private readonly TokenService _tokenService;

        public LoginController(ILoginServices loginServices, TokenService tokenService)
        {
            _loginServices = loginServices;
            _tokenService = tokenService;
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login(RequestLoginDto request)
        //{
        //    try
        //    {
        //        var result = await _loginServices.Login(request);

        //        if (result.Success)
        //        {
        //            var token = _tokenService.GenerateToken(result.Data.Id, result.Data.Username, result.Data.Email, result.Data.roles);
        //            result.Data.Token = token;

        //            return Ok(result);
        //        }

        //        return BadRequest(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            try
            {
                if (true)
                {
                    var token = _tokenService.GenerateToken("dnmi233290w0dhj890qa", "Kaique", "kaique@email.com", new List<Role> { new Role("adm", true), new Role("director", true), new Role("manager", true) });
                    return Ok(token);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
