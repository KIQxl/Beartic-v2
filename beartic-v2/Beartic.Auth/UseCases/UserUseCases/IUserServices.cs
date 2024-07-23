using Beartic.Auth.UseCases.UserUseCases.UserDtos;

namespace Beartic.Auth.UseCases.UserUseCases
{
    public interface IUserServices
    {
        public Task<UserResult> Create(CreateUserDto request);
    }
}
