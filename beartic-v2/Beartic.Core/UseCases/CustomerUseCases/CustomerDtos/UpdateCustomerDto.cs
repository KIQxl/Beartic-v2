using Beartic.Shared.Enums;

namespace Beartic.Core.UseCases.CustomerUseCases.CustomerDtos
{
    public class UpdateCustomerDto
    {
        public UpdateCustomerDto(string id, string firstName, string lastName, string email, string phone, string document, EDocumentType documentType, string street, string city, string state, string zipCode, string country, string number)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Document = document;
            DocumentType = documentType;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Number = number;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
        public EDocumentType DocumentType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
    }
}
