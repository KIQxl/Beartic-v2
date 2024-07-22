using Beartic.Core.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace Beartic.Core.ValueObjects
{
    public class Document : ValueObject
    {
        private Document() { }

        public Document(string number, EDocumentType type)
        {
            if (!ValidateCPF(number) && type == EDocumentType.CPF)
                AddNotification(new Notification("Document", "Documento inválido"));

            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        public static bool ValidateCPF(string cpf)
        {
            // Remover caracteres não numéricos do CPF
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verifica se o CPF possui 11 dígitos
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verifica se todos os caracteres são dígitos
            if (!long.TryParse(cpf, out _))
            {
                return false;
            }

            // Calcula os dígitos verificadores
            string digitos = cpf.Substring(0, 9);
            string verificador1 = CalcularDigitoVerificador(digitos);
            string verificador2 = CalcularDigitoVerificador(digitos + verificador1);

            // Verifica se os dígitos verificadores calculados são iguais aos do CPF
            return cpf.EndsWith(verificador1 + verificador2);
        }

        private static string CalcularDigitoVerificador(string digits)
        {
            int soma = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                soma += int.Parse(digits[i].ToString()) * (digits.Length + 1 - i);
            }

            int resto = soma % 11;
            int digito = resto < 2 ? 0 : 11 - resto;

            return digito.ToString();
        }
    }
}
