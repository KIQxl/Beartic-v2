using Flunt.Notifications;
using Flunt.Validations;

namespace Beartic.Auth.UseCases.UserUseCases.UserDtos
{
    public class UpdateUserDto : Notifiable
    {
        public UpdateUserDto(string id, string username, string firstname, string lastname, string email, string phone)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(id, "id", "Nome de usuário é obrigatório")
                .IsNotNullOrEmpty(username, "username", "Id inválido")
                .IsNotNullOrEmpty(firstname, "firstname", "Nome do usuário usuário é obrigatório")
                .IsNotNullOrEmpty(lastname, "lastname", "Sobrenome do usuário é obrigatório")
                .IsNotNullOrEmpty(email, "email", "Email é obrigatório")
                .IsNotNullOrEmpty(phone, "phone", "Telefone é obrigatório")
                );

            Id = id;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Phone = phone;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
