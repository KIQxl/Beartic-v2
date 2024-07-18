using Beartic.Application.Dtos;
using Beartic.Application.UseCases.CustomerUseCases.CreateCustomer;
using Flunt.Notifications;

namespace Beartic.Application.UseCases.CustomerUseCases.CustomerDtos
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
    public record GetCustomerData(string Id, string Name, string Document, string Phone, string Email);
}
