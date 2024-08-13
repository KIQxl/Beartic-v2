using Beartic.Auth.Dtos;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;

namespace Beartic.Auth.UseCases.LoginUseCases
{
    public interface IUserServices
    {
        public Task<LoginResult> Login(RequestLoginDto request);
    }
}
