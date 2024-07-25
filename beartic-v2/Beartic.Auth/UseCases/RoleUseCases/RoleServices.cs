using Beartic.Auth.Entities;
using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.RoleUseCases.RoleDtos;

namespace Beartic.Auth.UseCases.RoleUseCases
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _roleRepository;

        public RoleServices(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task ActiveDeactive(string id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
                return;

            role.ActiveDeactive();
        }

        public async Task<RoleResult> Create(CreateRoleDto request)
        {
            var role = new Role(request.Name, request.Active);

            if (role.Invalid)
                return new RoleResult(401, "Erro ao cadastrar perfil", role.Notifications);

            await _roleRepository.Add(role);

            return new RoleResult(201, "Perfil cadastrado", new RoleResultData(role.Id.ToString(), role.Name));
        }

        public async Task<RoleResult> GetByIdAsync(string id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
                return new RoleResult(404, "Perfil não encontrado");

            return new RoleResult(200, "Sucesso", new RoleResultData(role.Id.ToString(), role.Name));
        }
    }
}
