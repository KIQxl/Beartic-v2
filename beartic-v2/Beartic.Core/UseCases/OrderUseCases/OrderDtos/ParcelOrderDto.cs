namespace Beartic.Core.UseCases.OrderUseCases.OrderDtos
{
    public record ParcelOrderDto
    {
        public string Id { get; set; }
        public int Installments { get; set; }
    }
}
