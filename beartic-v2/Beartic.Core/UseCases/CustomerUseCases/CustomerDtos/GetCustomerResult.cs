using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.CustomerUseCases.CustomerDtos
{
    public class GetCustomerResult : Result<GetCustomerData>
    {
        public GetCustomerResult(int status, string message, GetCustomerData data) : base(status, message, data)
        {
        }

        public GetCustomerResult(int status, string message, IEnumerable<Notification>? notifications = null): base(status, message, notifications)
        {
        }
    }
    public record GetCustomerData(string Id, string Name, string Document, string Phone, string Email, string City, string ZipCode, string Street, string AddressNumber);
}
