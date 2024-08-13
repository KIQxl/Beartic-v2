using Beartic.Auth.Dtos;
using Beartic.Auth.UseCases.LoginUseCases.LoginDtos;

namespace Beartic.Auth.UseCases.LoginUseCases
{
    public interface ILoginServices
    {
        public Task<LoginResult> Login(RequestLoginDto request);
    }
}
