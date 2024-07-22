namespace Beartic.Application.UseCases.ProductUseCases.ProductDtos.ProductDtos
{
    public class CreateProductDto
    {
        public CreateProductDto(string title, string description, decimal price, int quantityOnHand)
        {
            Title = title;
            Description = description;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
