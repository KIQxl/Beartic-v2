using Beartic.Auth.ValueObjects;
using Beartic.Shared.Entities;
using Beartic.Shared.ValueObjects;
using Flunt.Validations;

namespace Beartic.Core.Entities
{
    public class User : BaseEntity
    {
        private User() { }
        public User(string username, Name name, Email email, Document document, Phone phone, Password password)
        {
            AddNotifications(name, email, document, phone, password, new Contract()
                .Requires()
                .IsNotNullOrEmpty(username, "username", "Nome de usuário obrigatório")
                .HasMinLen(username, 3, "username", "Nome de usuário deve conter no mínimo 3 caractéres"));

            Username = username;
            Name = name;
            Email = email;
            Document = document;
            Phone = phone;
            Password = password;
        }

        public string Username { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public Phone Phone { get; private set; }
        public Password Password { get; private set; }

        public void ChangePassword(Password password)
        {
            if (password.Invalid)
            {
                AddNotifications(password);
                return;
            }

            this.Password = password;
        }

        public void ChangeName(Name name)
        {
            if (name.Invalid)
            {
                AddNotifications(name);
                return;
            }

            this.Name = name;
        }

        public void ChangeDocument(Document document)
        {
            if (document.Invalid)
            {
                AddNotifications(document);
                return;
            }

            this.Document = document;
        }

        public void ChangeEmail(Email email)
        {
            if (email.Invalid)
            {
                AddNotifications(email);
                return;
            }

            this.Email = email;
        }

        public void ChangePhone(Phone phone)
        {
            if (Invalid)
            {
                AddNotifications(phone);
                return;
            }

            this.Phone = phone;
        }
    }
}
