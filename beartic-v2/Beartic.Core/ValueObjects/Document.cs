using Beartic.Core.Enums;
using Flunt.Validations;

namespace Beartic.Core.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            if (!IsValidCPF(number) && type == EDocumentType.CPF)
                AddNotifications();

            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        public static bool IsValidCPF(string cpf)
        {
            // Remove any non-numeric characters
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // CPF must have 11 digits
            if (cpf.Length != 11)
                return false;

            // Check if all digits are the same (invalid CPF)
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Calculate the first digit verifier
            int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * multiplicadores1[i];
            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            // Calculate the second digit verifier
            int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * multiplicadores2[i];
            soma += digito1 * multiplicadores2[9];
            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            // Check if the calculated digits match the input digits
            return cpf[9] == digito1 && cpf[10] == digito2;
        }
    }
}
