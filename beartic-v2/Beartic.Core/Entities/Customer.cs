﻿using Beartic.Core.ValueObjects;
using Flunt.Validations;

namespace Beartic.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(Name name, string phone, Document document, Password password, Email email)
        {
            AddNotifications(name, document, password, email, new Contract()
                .Requires()
                .IsNotNullOrEmpty(phone, "Phone number", "Número de telefone é obrigatório")
                .HasLen(phone, 11, "Phone number", "Número de telefone inválido"));

            Name = name;
            Phone = phone;
            Document = document;
            Password = password;
            Email = email;
        }

        public Name Name { get; private set; }
        public string Phone { get; private set; }
        public Document Document { get; private set; }
        public Password Password { get; private set; }
        public Email Email { get; private set; }

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
    }
}
