using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.CustomerUseCases.CustomerDtos
{
    public class CustomerResult : Result<CustomerResultData>
    {
        public CustomerResult(int status, string message, CustomerResultData data) : base(status, message, data)
        {
        }

        public CustomerResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record CustomerResultData(string Id, string Name, string Document, string Email, string Phone, string Street, string Number, string City);
}
