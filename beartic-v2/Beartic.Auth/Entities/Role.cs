using Beartic.Core.Entities;
using Beartic.Shared.Entities;
using Flunt.Validations;

namespace Beartic.Auth.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            
        }

        public Role(string name, bool active)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(name, "name", "Nome do perfil é obrigatório")
                .HasMinLen(name, 2, "name", "Nome do perfil deve conter no mínimo 2 caractéres")
            );

            Name = name;
            Active = active;
            Users = new List<User>();
        }

        public string Name { get; private set; }
        public bool Active { get; private set; }
        public IList<User> Users { get; private set; }

        public void ActiveDeactive() => this.Active = !this.Active;
    }
}
