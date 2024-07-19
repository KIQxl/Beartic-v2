using Beartic.Application.UseCases.OrderItemUseCases.OrderItemDto;

namespace Beartic.Application.UseCases.OrderUseCases.OrderDtos
{
    public record CreateOrderDto(string customerId, IList<CreateOrderItemDto> orderItems);
}
