namespace Beartic.Application.UseCases.ProductUseCases.ProductDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
