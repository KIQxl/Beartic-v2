using Beartic.Core.Entities;
using Beartic.Core.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.EntitiesTests
{
    [TestClass]
    public class OrderTests
    {
        private Product _product1 = new Product("Produto 1", "Teste", 100m, 10);
        private Product _product2 = new Product("Produto 2", "Teste 2", 200m, 10);
        private Customer _customer = new Customer(new Name("Kaique", "Alves"), "11977268607", new Document("99403111097", Core.Enums.EDocumentType.CPF), new Password("123456789"), new Email("kaique@email.com.br"));

        [TestMethod]
        public void ReturnTrueGivenValidOrder()
        {
            var order = new Order(_customer);

            order.AddItem(new OrderItem(_product1, 3));
            order.AddItem(new OrderItem(_product2, 1));
            order.AddItem(new OrderItem(_product2, 1));

            Assert.AreEqual(700m, order.Installment.Price);
        }

        [TestMethod]
        public void Return100WhenParcelOrder()
        {
            var order = new Order(_customer);

            order.AddItem(new OrderItem(_product1, 3));
            order.Parcel(3);

            Assert.IsTrue(100m == order.Installment.InstallmentPrice && order.Installment.Price == 300m);
        }

        [TestMethod]
        public void Return200WhenPaidOrder()
        {
            var order = new Order(_customer);
            order.AddItem(new OrderItem(_product1, 3));

            order.Pay(100);

            Assert.IsTrue(order.Installment.Price == 200 && order.Installment.Installments == 1);
        }

        [TestMethod]
        public void Return200WhenPaidParcelOrder()
        {
            var order = new Order(_customer);
            order.AddItem(new OrderItem(_product1, 3));
            order.Parcel(3);
            order.Pay(100);

            Assert.IsTrue(order.Installment.Price == 200 && order.Installment.Installments == 2);
        }
    }
}
