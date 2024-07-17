using Flunt.Notifications;

namespace Beartic.Core.Entities
{
    public class BaseEntity : Notifiable
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
