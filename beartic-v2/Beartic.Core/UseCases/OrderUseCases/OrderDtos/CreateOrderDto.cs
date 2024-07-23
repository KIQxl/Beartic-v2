using Beartic.Core.UseCases.OrderItemUseCases.OrderItemDto;

namespace Beartic.Core.UseCases.OrderUseCases.OrderDtos
{
    public record CreateOrderDto(string customerId, IList<CreateOrderItemDto> orderItems);
}
