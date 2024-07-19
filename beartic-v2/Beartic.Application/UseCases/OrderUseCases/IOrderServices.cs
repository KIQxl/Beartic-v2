using Beartic.Application.UseCases.OrderUseCases.OrderDtos;

namespace Beartic.Application.UseCases.OrderUseCases
{
    public interface IOrderServices
    {
        public Task<OrderResult> CreateOrder(CreateOrderDto request);
    }
}
