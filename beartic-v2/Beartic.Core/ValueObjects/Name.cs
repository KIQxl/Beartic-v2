using Flunt.Validations;

namespace Beartic.Core.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstname, string lastname)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(firstname, "Name Firstname", "Primeiro nome é obrigatório")
                .HasMinLen(firstname, 3, "Name Firstname", "Primeiro nome deve conter no mínimo 3 caractéres")
                .IsNotNullOrEmpty(lastname, "Name Lastname", "Sobrenome é obrigatório")
                .HasMinLen(lastname, 3, "Name Lastname", "Sobrenome deve conter no mínimo 3 caractéres")
                );

            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
