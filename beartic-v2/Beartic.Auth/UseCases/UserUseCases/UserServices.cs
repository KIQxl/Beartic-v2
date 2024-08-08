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
        private readonly IRoleRepository _roleRepository;

        public UserServices(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserResult> Create(CreateUserDto request)
        {
            var name = new Name(request.Fisrtname, request.Lastname);
            var document = new Document(request.Document, request.DocumentType);
            var email = new Email(request.Email);
            var phone = new Phone(request.Phone);
            var password = new Password(request.Password);
            var user = new User(request.Username, name, email, document, phone, password);

            foreach(string id in request.Roles)
            {
                var role = await _roleRepository.GetByIdAsync(id);
                if(role != null)
                {
                    user.AddRole(role);
                }
            }

            if (user.Invalid)
                return new UserResult(400, "Usuário não cadastrado", user.Notifications);

            if(await _userRepository.EmailExists(user.Email.Address))
                return new UserResult(400, "O documento informado já está cadastrado.");

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
                return new LoginResult(400, "Credenciais incorretas");

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
                return new UserResult(400, "Erro ao atualizar usuário", request.Notifications);

            var user = await _userRepository.GetByIdAsync(request.Id);

            if(user == null)
                return new UserResult(404, "Usuário não encontrado");

            _userRepository.Update(user);

            return new UserResult(201, "Usuário atualizado.", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number));
        }

        public async Task<UserResult> AddRole(string userId, string roleId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null)
                return new UserResult(404, "Perfil não encontrado.");

            user.AddRole(role);

            _userRepository.Update(user);

            return new UserResult(200, "Perfil de usuário adicionado.");
        }

        public async Task<UserResult> RemoveRole(string userId, string roleId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            var role = await _roleRepository.GetByIdAsync(roleId);
            if(role == null)
                return new UserResult(404, "Perfil não encontrado.");

            user.RemoveRole(role.Name);

            _userRepository.Update(user);

            return new UserResult(200, "Perfil de usuário removido");
        }
    }
}
