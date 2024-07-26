namespace Beartic.Application.UseCases.ProductUseCases.ProductDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public UpdateProductDto(string id, string title, string description, decimal price, int quantityOnHand)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
