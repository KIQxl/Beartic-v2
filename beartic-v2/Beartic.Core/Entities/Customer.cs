using Beartic.Core.ValueObjects;
using Flunt.Validations;

namespace Beartic.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(Name name, Phone phone, Document document, Password password, Email email, Address address)
        {
            AddNotifications(name, phone, document, password, email, address);

            Name = name;
            Phone = phone;
            Document = document;
            Password = password;
            Email = email;
            Address = address;
        }

        public Name Name { get; private set; }
        public Phone Phone { get; private set; }
        public Document Document { get; private set; }
        public Password Password { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Order? Orders { get; private set; }

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
            if(email.Invalid)
            {
                AddNotifications(email);
                return;
            }

            this.Email = email;
        }

        public void ChangePassword(Password password)
        {
            if (password.Invalid)
            {
                AddNotifications(password);
                return;
            }

            this.Password = password;
        }

        public void ChangeAddress(Address address)
        {
            if (address.Invalid)
            {
                AddNotifications(address);
                return;
            }

            this.Address = address;
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
