using Beartic.Application.Dtos;
using Beartic.Core.Enums;
using Flunt.Notifications;

namespace Beartic.Application.UseCases.OrderUseCases.OrderDtos
{
    public class OrderResult : Result<OrderResultData>
    {
        public OrderResult(int status, string message, OrderResultData data) : base(status, message, data)
        {
        }

        public OrderResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record OrderResultData(string Id, string Customer, DateTime Date, EOrderStatus Status, decimal Price);
}
