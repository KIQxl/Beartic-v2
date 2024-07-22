using Flunt.Validations;
using System.Security.Cryptography;
using System.Text;

namespace Beartic.Core.ValueObjects
{
    public class Password : ValueObject
    {
        private Password() { }

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
            string passwordWithSalt = password + saltKey;

            using (var sha256 = SHA256.Create())
            {
                // convertendo o resultado da concatenação para um array de bytes
                byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);

                // criando o hash
                byte[] hash = sha256.ComputeHash(bytes);

                // convertendo o hash para uma string base 64 e retornando a mesma
                return Convert.ToBase64String(hash);
            }
        }

        public string GenerateSaltKey()
        {
            byte[] saltBytes = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }
    }
}
