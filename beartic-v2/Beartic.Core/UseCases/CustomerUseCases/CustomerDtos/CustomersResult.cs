using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.CustomerUseCases.CustomerDtos
{
    public class CustomersResult : Result<IList<CustomerResultData>>
    {
        public CustomersResult(int status, string message, IList<CustomerResultData> data) : base(status, message, data)
        {
        }

        public CustomersResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }
}
