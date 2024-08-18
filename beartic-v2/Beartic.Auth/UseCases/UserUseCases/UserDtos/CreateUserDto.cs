using Beartic.Shared.Enums;

namespace Beartic.Auth.UseCases.UserUseCases.UserDtos
{
    public class CreateUserDto
    {
        public CreateUserDto()
        {
            
        }
        public CreateUserDto(string username, string fisrtname, string lastname, string email, string document, EDocumentType documentType, string phone, string password, IList<string> roles)
        {
            Username = username;
            Firstname = fisrtname;
            Lastname = lastname;
            Email = email;
            Document = document;
            DocumentType = documentType;
            Phone = phone;
            Password = password;
            Roles = roles;
        }

        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public EDocumentType DocumentType { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public IList<string> Roles { get; set; }
    }
}
