using Beartic.Shared.Entities;
using Flunt.Validations;

namespace Beartic.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category(string name, string description)
        {
            AddNotifications( new Contract()
                .IsNotNullOrEmpty(name, "category name", "O nome da categoria é obrigatório")
                .IsNotNullOrEmpty(description, "category description", "A descrição da categoria é obrigatória"));

            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public IList<Product> Products { get; private set; }

        public void ChangeCategory(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
