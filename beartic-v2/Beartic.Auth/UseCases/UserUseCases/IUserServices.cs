using Beartic.Auth.Dtos;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;

namespace Beartic.Auth.UseCases.UserUseCases
{
    public interface IUserServices
    {
        public Task<UserResult> Create(CreateUserDto request);
        public Task<UserResult> Update(UpdateUserDto request);
        public Task<UserResult> Remove(string id);
        public Task<UserResult> GetById(string id);
        public Task<LoginResult> Login(RequestLoginDto request);
    }
}
