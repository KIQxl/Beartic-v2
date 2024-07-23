using Beartic.Core.Entities;
using Beartic.Shared.Enums;
using Beartic.Shared.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.EntitiesTests
{
    [TestClass]
    public class CustomerTests
    {
        private Customer _customer = new Customer(new Name("Kaique", "Alves"), new Phone("11977268607"), new Document("99403111097", EDocumentType.CPF), new Email("kaique@email.com.br"), new Address("Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202"));

        [TestMethod]
        public void ReturnTrueGivenValidCustomerParameters()
        {
            Assert.IsTrue(_customer.Valid);
        }

        [TestMethod]
        public void ReturnFalseGivenInvalidCustomerParameters()
        {
            Name name = new Name("", "A");
            Phone phone = new Phone("1607");
            Document document = new Document("", EDocumentType.CPF);
            Email email = new Email("kaiqueemail.com.br");
            Address address = new Address("", "São Paulo", "São Paulo", "08031450", "Brasil", "");

            Customer customer = new Customer(name, phone, document, email, address);

            Assert.IsFalse(customer.Valid);
        }

        [TestMethod]
        public void ReturnTrueWhenChangeEmail()
        {
            var email = _customer.Email.Address;
            Email newEmail = new Email("kaique@bol.com.br");

            _customer.ChangeEmail(newEmail);

            Assert.IsTrue(email != newEmail.Address && _customer.Email.Address == newEmail.Address);
        }

        [TestMethod]
        public void ReturnTrueWhenChangeName()
        {
            var name = _customer.Name.ToString();
            Name newName = new Name("Teste", "Teste");

            _customer.ChangeName(newName);

            Assert.IsTrue(name != _customer.Name.ToString());
        }

        [TestMethod]
        public void ReturnTrueWhenChangeDocument()
        {
            var document = _customer.Document.Number;
            Document newDocument = new Document("77670999039", EDocumentType.CPF);

            _customer.ChangeDocument(newDocument);

            Assert.IsTrue(_customer.Document.Number != document);
        }
    }
}
