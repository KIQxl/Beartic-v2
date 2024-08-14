using Beartic.Auth.Entities;
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

    public record LoginResultData
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<Role> roles { get; set; }
        public string? Token { get; set; } = string.Empty;
    }
}
