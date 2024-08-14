using Beartic.Shared.Dtos;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beartic.Auth.UseCases.RoleUseCases.RoleDtos
{
    public class RolesResult : Result<IList<RoleResultData>>
    {
        public RolesResult(int status, string message, IList<RoleResultData> data) : base(status, message, data)
        {
        }

        public RolesResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }
}
