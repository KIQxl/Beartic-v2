using Beartic.Core.UseCases.OrderUseCases.OrderDtos;

namespace Beartic.Core.UseCases.OrderUseCases
{
    public interface IOrderServices
    {
        public Task<OrderResult> CreateOrder(CreateOrderDto request);
        public Task<OrderResult> GetOrderByIdAsync(string id);
        public Task<OrderResult> PayOrderAsync(PayOrderDto payRequest);
        public Task<OrderResult> ParcelOrderAsync(ParcelOrderDto parcelRequest);
        public Task<OrdersResult> ListOrdersAsync();
        public Task<OrderResult> CancelOrderAsync(string id);
    }
}
