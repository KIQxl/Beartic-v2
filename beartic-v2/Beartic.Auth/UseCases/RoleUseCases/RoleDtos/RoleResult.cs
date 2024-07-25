using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Auth.UseCases.RoleUseCases.RoleDtos
{
    public class RoleResult : Result<RoleResultData>
    {
        public RoleResult(int status, string message, RoleResultData data) : base(status, message, data)
        {
        }

        public RoleResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record RoleResultData(string Id, string Name);
}
