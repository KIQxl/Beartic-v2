using Beartic.Shared.Enums;

namespace Beartic.Core.UseCases.CustomerUseCases.CustomerDtos
{
    public class CreateCustomerDto
    {
        public CreateCustomerDto()
        {
            
        }

        public CreateCustomerDto(string firstname, string lastname, string phone, string email, string document, EDocumentType documentType, string street, string city, string state, string zipCode, string country, string number)
        {
            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;
            Email = email;
            Document = document;
            DocumentType = documentType;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Number = number;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public EDocumentType DocumentType { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public string Number { get; private set; }
    }
}
