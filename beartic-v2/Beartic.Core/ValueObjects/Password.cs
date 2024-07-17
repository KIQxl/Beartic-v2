using Flunt.Validations;

namespace Beartic.Core.ValueObjects
{
    public class Password : ValueObject
    {
        public Password(string password)
        {
            AddNotifications( new Contract()
                .Requires()
                .IsNotNullOrEmpty(password, "password", "Senha é obrigatória")
                .HasMinLen(password, 8, "password", "Senha deve conter no mínimo 8 dígitos")
                );

            SaltKey = GenerateSaltKey();
            PasswordHash = GenerateHashByPassword(password, this.SaltKey);
        }

        public string PasswordHash { get; private set; }
        public string SaltKey { get; private set;}

        public string GenerateHashByPassword(string password, string saltKey)
        {
            return string.Empty;
        }

        public string GenerateSaltKey()
        {
            return string .Empty;
        }
    }
}
