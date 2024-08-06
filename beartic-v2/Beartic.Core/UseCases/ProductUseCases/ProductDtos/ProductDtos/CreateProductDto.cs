namespace Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos
{
    public class CreateProductDto
    {
        public CreateProductDto(string title, string description, decimal price, int quantityOnHand, IList<string> categories)
        {
            Title = title;
            Description = description;
            Price = price;
            QuantityOnHand = quantityOnHand;
            Categories = categories;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
        public IList<string>? Categories { get; set; }
    }
}
