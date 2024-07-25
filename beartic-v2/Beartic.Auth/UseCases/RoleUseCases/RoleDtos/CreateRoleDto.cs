namespace Beartic.Auth.UseCases.RoleUseCases.RoleDtos
{
    public record CreateRoleDto
    {
        public CreateRoleDto(string name, bool active)
        {
            Name = name;
            Active = active;
        }

        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
