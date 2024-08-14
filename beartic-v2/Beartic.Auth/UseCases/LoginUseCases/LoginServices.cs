using Beartic.Auth.Dtos;
using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.LoginUseCases.LoginDtos;

namespace Beartic.Auth.UseCases.LoginUseCases
{
    public class LoginServices : ILoginServices
    {
        private IUserRepository _userRepository;

        public LoginServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResult> Login(RequestLoginDto request)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null)
                return new LoginResult(404, "Usuário não encontrado");

            if (!user.Password.Auth(request.Password))
                return new LoginResult(400, "Credenciais incorretas");

            return new LoginResult(200, "Autenticado", new LoginResultData{
                Id = user.Id.ToString(),
                Username = user.Username,
                Email = user.Email.Address,
                roles = user.Roles
            });
        }
    }
}
