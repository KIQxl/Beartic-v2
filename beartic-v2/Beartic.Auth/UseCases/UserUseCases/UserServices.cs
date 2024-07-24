using Beartic.Auth.Dtos;
using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;
using Beartic.Auth.ValueObjects;
using Beartic.Core.Entities;
using Beartic.Shared.ValueObjects;

namespace Beartic.Auth.UseCases.UserUseCases
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<UserResult> Create(CreateUserDto request)
        {
            var name = new Name(request.Fisrtname, request.Lastname);
            var document = new Document(request.Document, request.DocumentType);
            var email = new Email(request.Email);
            var phone = new Phone(request.Phone);
            var password = new Password(request.Password);
            var user = new User(request.Username, name, email, document, phone, password);

            if (user.Invalid)
                return new UserResult(401, "Usuário não cadastrado", user.Notifications);

            if(await _userRepository.EmailExists(user.Email.Address))
                return new UserResult(401, "O documento informado já está cadastrado.");

            await _userRepository.Add(user);

            return new UserResult(201, "Usuário cadastrado", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number));
        }

        public async Task<UserResult> GetById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            return new UserResult(200, "Sucesso", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number));
        }

        public async Task<LoginResult> Login(RequestLoginDto request)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null)
                return new LoginResult(404, "Usuário não encontrado");

            if(!user.Password.Auth(request.Password))
                return new LoginResult(401, "Credenciais incorretas");

            return new LoginResult(200, "Autenticado", new LoginResultData(user.Id.ToString(), user.Username, user.Email.Address));
        }

        public async Task<UserResult> Remove(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            _userRepository.Remove(user);

            return new UserResult(200, "Sucesso", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number));
        }

        public async Task<UserResult> Update(UpdateUserDto request)
        {
            if(request.Invalid)
                return new UserResult(401, "Erro ao atualizar usuário", request.Notifications);

            var user = await _userRepository.GetByIdAsync(request.Id);

            if(user == null)
                return new UserResult(404, "Usuário não encontrado");

            await _userRepository.Update(user);

            return new UserResult(201, "Usuário atualizado.", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number));
        }
    }
}
