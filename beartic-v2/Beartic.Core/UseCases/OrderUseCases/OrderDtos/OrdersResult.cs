using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.OrderUseCases.OrderDtos
{
    public class OrdersResult : Result<IList<OrderResultData>>
    {
        public OrdersResult(int status, string message, IList<OrderResultData> data) : base(status, message, data)
        {
        }

        public OrdersResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }
}
