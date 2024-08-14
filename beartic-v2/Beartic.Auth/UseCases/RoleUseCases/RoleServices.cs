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

        public async Task<RoleResult> ActiveDeactive(string id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
                return new RoleResult(404, "Perfil não encontrado");

            role.ActiveDeactive();

            _roleRepository.Update(role);

            return new RoleResult(200, "Role modificada", new RoleResultData(role.Id.ToString(), role.Name));
        }

        public async Task<RoleResult> Create(CreateRoleDto request)
        {
            var role = new Role(request.Name, request.Active);

            if (role.Invalid)
                return new RoleResult(400, "Erro ao cadastrar perfil", role.Notifications);

            if (await _roleRepository.GetByName(request.Name))
                return new RoleResult(400, "Perfil já existe no sistema");

            await _roleRepository.Add(role);

            return new RoleResult(201, "Perfil cadastrado", new RoleResultData(role.Id.ToString(), role.Name));
        }

        public async Task<RolesResult> GetAll()
        {
            var roles = await _roleRepository.GetAll();

            if (!roles.Any())
                return new RolesResult(404, "Nenhum perfil cadastrado");

            var rolesResultList = new List<RoleResultData>();
            foreach (var role in roles)
            {
                var roleResultData = new RoleResultData(role.Id.ToString(), role.Name);

                rolesResultList.Add(roleResultData);
            }

            return new RolesResult(200, "Encontrados", rolesResultList);
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
