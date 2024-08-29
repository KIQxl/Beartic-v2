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
           try
            {
                var name = new Name(request.Firstname, request.Lastname);
                var document = new Document(request.Document, request.DocumentType);
                var email = new Email(request.Email);
                var phone = new Phone(request.Phone);
                var password = new Password(request.Password);
                var user = new User(request.Username, name, email, document, phone, password);

                if (user.Invalid)
                    return new UserResult(400, "Usuário não cadastrado", user.Notifications);

                if (await _userRepository.EmailExists(user.Email.Address))
                    return new UserResult(400, "O Email informado já está cadastrado.");

                foreach (string roleName in request.Roles)
                {
                    var role = await _roleRepository.GetRoleByName(roleName);
                    if (role == null)
                    {
                        return new UserResult(400, "Usuário não cadastrado, o perfil não foi encontrado");
                    }

                    user.AddRole(role);
                }

                await _userRepository.Add(user);

                return new UserResult(201, "Usuário cadastrado", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number, user.Roles));
            }
            catch
            {
                return null;
            }
        }

        public async Task<UserResult> GetById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            return new UserResult(200, "Sucesso", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number, user.Roles));
        }

        public async Task<UserResult> Remove(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            _userRepository.Remove(user);

            return new UserResult(200, "Sucesso", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number, user.Roles));
        }

        public async Task<UserResult> Update(UpdateUserDto request)
        {
            if(request.Invalid)
                return new UserResult(400, "Erro ao atualizar usuário", request.Notifications);

            var user = await _userRepository.GetByIdAsync(request.Id);

            if(user == null)
                return new UserResult(404, "Usuário não encontrado");

            var document = new Document(request.Document, request.DocumentType);
            var phone = new Phone(request.Phone);
            var email = new Email(request.Email);
            var name = new Name(request.Firstname, request.Lastname);


            user.ChangeDocument(document);
            user.ChangePhone(phone);
            user.ChangeEmail(email);
            user.ChangeName(name);

            _userRepository.Update(user);

            return new UserResult(201, "Usuário atualizado.", new UserResultData(user.Id.ToString(), user.Username, user.Email.Address, user.Phone.Number, user.Roles));
        }

        public async Task<UserResult> AddRole(AlterRole request)
        {
            var user = await _userRepository.GetByIdAsync(request.userId);
            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            var role = await _roleRepository.GetByIdAsync(request.roleId);
            if (role == null)
                return new UserResult(404, "Perfil não encontrado.");

            user.AddRole(role);

            _userRepository.Update(user);

            return new UserResult(200, "Perfil de usuário adicionado.");
        }

        public async Task<UserResult> RemoveRole(AlterRole request)
        {
            var user = await _userRepository.GetByIdAsync(request.userId);
            if (user == null)
                return new UserResult(404, "Usuário não encontrado");

            var role = await _roleRepository.GetByIdAsync(request.roleId);
            if(role == null)
                return new UserResult(404, "Perfil não encontrado.");

            user.RemoveRole(role.Name);

            _userRepository.Update(user);

            return new UserResult(200, "Perfil de usuário removido");
        }

        public async Task<UsersResult> GetAll()
        {
            var users = await _userRepository.GetAll();

            if (users == null || !users.Any())
                return new UsersResult(404, "Nenhum usuário encontrado");

            var usersResult = new List<UserResultData>();

            foreach (var user in users)
            {
                usersResult.Add(new UserResultData(user.Id.ToString(), user.Name.ToString(), user.Email.Address, user.Phone.Number, user.Roles));
            }

            return new UsersResult(200, "Encontrados", usersResult);
        }

        public async Task<UserResult> ChangePassword(ChangePasswordDto request)
        {
            if(request.Password != request.ConfirmPassword)
                return new UserResult(401, "As senhas não conferem");

            var user = await _userRepository.GetByEmailAsync(request.Email);

            if(user is null)
                return new UserResult(404, "Usuário não encontrado");

            var password = new Password(request.Password);

            user.ChangePassword(password);

            _userRepository.Update(user);

            return new UserResult(200, "Senha alterada com sucesso!");
        }
    }
}
