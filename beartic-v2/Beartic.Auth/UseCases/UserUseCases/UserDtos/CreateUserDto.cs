using Beartic.Shared.Enums;

namespace Beartic.Auth.UseCases.UserUseCases.UserDtos
{
    public class CreateUserDto
    {
        public CreateUserDto(string id, string username, string fisrtname, string lastname, string email, string document, EDocumentType documentType, string phone, string password)
        {
            Id = id;
            Username = username;
            Fisrtname = fisrtname;
            Lastname = lastname;
            Email = email;
            Document = document;
            DocumentType = documentType;
            Phone = phone;
            Password = password;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Fisrtname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public EDocumentType DocumentType { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
