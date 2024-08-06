namespace Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public UpdateProductDto(string id, string title, string description, decimal price, int quantityOnHand, string? firstImageUrl = null, string? secondImageUrl = null, string? thirdImageUrl = null)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            QuantityOnHand = quantityOnHand;
            FirstImageUrl = firstImageUrl;
            SecondImageUrl = secondImageUrl;
            ThirdImageUrl = thirdImageUrl;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
        public string? FirstImageUrl { get; set; }
        public string? SecondImageUrl { get; set; }
        public string? ThirdImageUrl { get; set;}
    }
}
