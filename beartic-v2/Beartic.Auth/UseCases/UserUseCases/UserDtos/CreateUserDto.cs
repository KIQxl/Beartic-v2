using Beartic.Shared.Enums;

namespace Beartic.Auth.UseCases.UserUseCases.UserDtos
{
    public class CreateUserDto
    {
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
