using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Auth.UseCases.UserUseCases.UserDtos
{
    public class UserResult : Result<UserResultData>
    {
        public UserResult(int status, string message, UserResultData data) : base(status, message, data)
        {
        }

        public UserResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record UserResultData(string Id, string Username, string Email, string Phone);
}
