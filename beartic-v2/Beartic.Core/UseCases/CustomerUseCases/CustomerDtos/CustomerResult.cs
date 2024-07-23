using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.CustomerUseCases.CustomerDtos
{
    public class CustomerResult : Result<CreateCustomerData>
    {
        public CustomerResult(int status, string message, CreateCustomerData data) : base(status, message, data)
        {
        }

        public CustomerResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record CreateCustomerData(string Id, string Name, string Document);
}
