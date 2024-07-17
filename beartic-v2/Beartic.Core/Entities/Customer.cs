using Beartic.Core.ValueObjects;

namespace Beartic.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Name Name { get; private set; }
        public string Phone { get; private set; }
        public Document Document { get; private set; }
        public Password Password { get; private set; }
        public Email Email { get; private set; }
    }
}
