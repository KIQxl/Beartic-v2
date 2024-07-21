using Flunt.Validations;

namespace Beartic.Core.ValueObjects
{
    public class Phone : ValueObject
    {
        public Phone(string number)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(number, "Phone Number", "Número de telefone é obrigatório")
                .HasLen(number, 11, "Phone Number", "Número de telefone inválido"));

            Number = number;
        }

        public string Number { get; private set; }
    }
}
