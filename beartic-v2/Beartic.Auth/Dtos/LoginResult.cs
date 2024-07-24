using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Auth.Dtos
{
    public class LoginResult : Result<LoginResultData>
    {
        public LoginResult(int status, string message, LoginResultData data) : base(status, message, data)
        {
        }

        public LoginResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record LoginResultData(string Id, string Username, string Email, string? Token = "");
}
