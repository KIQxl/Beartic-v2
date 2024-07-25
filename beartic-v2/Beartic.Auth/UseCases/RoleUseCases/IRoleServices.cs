using Beartic.Auth.UseCases.RoleUseCases.RoleDtos;

namespace Beartic.Auth.UseCases.RoleUseCases
{
    public interface IRoleServices
    {
        public Task<RoleResult> GetByIdAsync(string id);
        public Task<RoleResult> Create(CreateRoleDto request);
        public Task ActiveDeactive(string id);
    }
}
