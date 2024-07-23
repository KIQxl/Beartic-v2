using Flunt.Validations;

namespace Beartic.Shared.ValueObjects
{
    public class Address : ValueObject
    {
        private Address() { }

        public Address(string street, string city, string state, string zipCode, string country, string number)
        {
            AddNotifications( new Contract()
                .Requires()
                .IsNotNullOrEmpty(street, "Address Street", "Nome da rua obrigatório")
                .IsNotNullOrEmpty(city, "Address City", "Nome da cidade obrigatório")
                .IsNotNullOrEmpty(state, "Address State", "Nome do estado obrigatório")
                .IsNotNullOrEmpty(zipCode, "Address Zip Code", "Número do CEP obrigatório")
                .IsNotNullOrEmpty(country, "Address País", "Nome País obrigatório")
                .IsNotNullOrEmpty(number, "Address Number", "Número residencial obrigatório")
                );

            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Number = number;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set;}
        public string Country { get; private set;}
        public string Number { get; private set;}
    }
}
