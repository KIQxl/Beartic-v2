using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Auth.UseCases.UserUseCases.UserDtos
{
    public class UsersResult : Result<IList<UserResultData>>
    {
        public UsersResult(int status, string message, IList<UserResultData> data) : base(status, message, data)
        {
        }

        public UsersResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }
}
