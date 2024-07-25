using Beartic.Shared.Entities;
using Flunt.Validations;

namespace Beartic.Core.Entities
{
    public class Product : BaseEntity
    {
        private Product() { }
        public Product(string title, string description, decimal price, int quantityOnHand)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(title, "Product Title", "O Nome do produto é obrigatório")
                .IsNotNullOrEmpty(description, "Product Description", "A Descrição  do produto é obrigatório")
                .HasMinLen(title, 2, "Product Title", "O nome do produto deve conter no mínimo 2 caractéres")
                .IsGreaterThan(price, 0, "Price", "O valor do produto deve ser maior 0")
                .IsNotNull(price, "Price", "O valor do produto é obrigatório")
                .IsGreaterThan(quantityOnHand, 0, "QuantityOnHand", "A quantidade do produto deve ser maior 0")
                .IsNotNull(quantityOnHand, "QuantityOnHand", "A quantidade do produto é obrigatória")
                );

            Title = title;
            Description = description;
            Price = price;
            QuantityOnHand = quantityOnHand;
            Categories = new List<Category>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }
        public IList<Category> Categories { get; private set; }

        public void DecreaseQuantityProduct(int quantity)
        {
            if (QuantityOnHand - quantity < 0)
                return;

            this.QuantityOnHand -= quantity;
        }

        public void IncreaseQuantityProduct(int quantity)
        {
            if (QuantityOnHand + quantity < 0)
                return;

            this.QuantityOnHand += quantity;
        }

        public void SetProduct(string title, string description, decimal price, int quantity)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(title, "Product Title", "O Nome do produto é obrigatório")
                .IsNotNullOrEmpty(description, "Product Description", "A Descrição  do produto é obrigatório")
                .HasMinLen(title, 2, "Product Title", "O nome do produto deve conter no mínimo 2 caractéres")
                .IsGreaterThan(price, 0, "Price", "O valor do produto deve ser maior 0")
                .IsNotNull(price, "Price", "O valor do produto é obrigatório")
                .IsGreaterThan(quantity, 0, "QuantityOnHand", "A quantidade do produto deve ser maior 0")
                .IsNotNull(quantity, "QuantityOnHand", "A quantidade do produto é obrigatória")
            );

            if (Valid)
            {   
                this.Title = title;
                this.Description = description;
                this.Price = price;
                this.QuantityOnHand = quantity;
                return;
            }
        }

        public void AddCategory(Category category)
        {
            if (category.Invalid)
            {
                AddNotifications(category);
                return;
            }

            Categories.Add(category);
        }
    }
}
