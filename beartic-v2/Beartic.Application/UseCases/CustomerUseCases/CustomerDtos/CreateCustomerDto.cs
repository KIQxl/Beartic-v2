using Beartic.Core.Enums;

namespace Beartic.Application.UseCases.CustomerUseCases.CustomerDtos
{
    public class CreateCustomerDto
    {
        public CreateCustomerDto()
        {
            
        }
        public CreateCustomerDto(string firstname, string lastname, string phone, string email, string document, EDocumentType documentType, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;
            Email = email;
            Document = document;
            DocumentType = documentType;
            Password = password;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public EDocumentType DocumentType { get; set; }
        public string Password { get; set; }
    }
}
