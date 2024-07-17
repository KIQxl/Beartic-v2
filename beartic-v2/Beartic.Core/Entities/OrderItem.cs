using Flunt.Validations;

namespace Beartic.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(Product product, int quantity)
        {

            AddNotifications(product, new Contract()
                .IsGreaterThan(quantity, 0, "Order Item Quantity", "Quantidade de produtos inválida")
                .IsLowerOrEqualsThan(quantity, product.QuantityOnHand, "Order Item Quantity", "Quantidade de produtos insuficientes"));

            Product = product;
            Price = product != null ? product.Price : 0;
            Quantity = quantity;

            product.DecreaseQuantityProduct(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal SubTotal()
        {
            return Price * Quantity;
        }
    }
}
