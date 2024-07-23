using Flunt.Validations;

namespace Beartic.Shared.ValueObjects
{
    public class Email : ValueObject
    {
        private Email() { }
        public Email(string address)
        {
            AddNotifications( new Contract()
                .Requires()
                .IsNotNullOrEmpty(address, "Email Address", "O endereço de email é obrigatório")
                .IsEmail(address, "Email Address", "Endereço de email inválido"));

            Address = address;
        }

        public string Address { get; private set; }
    }
}
