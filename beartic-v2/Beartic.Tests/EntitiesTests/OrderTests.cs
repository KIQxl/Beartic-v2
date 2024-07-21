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
        private Product _product3 = new Product(null, "", 0, 10);
        private Customer _customer = new Customer(new Name("Kaique", "Alves"), new Phone("11977268607"), new Document("99403111097", Core.Enums.EDocumentType.CPF), new Password("123456789"), new Email("kaique@email.com.br"), new Address("Parreira Brava", "São Paulo", "São Paulo", "08031450", "Brasil", "202"));

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

            Assert.IsTrue(100m == order.Installment.InstallmentPrice && order.Installment.Price == 300m && order.Status == Core.Enums.EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        public void Return200WhenPaidOrder()
        {
            var order = new Order(_customer);
            order.AddItem(new OrderItem(_product1, 3));

            order.Pay(100);

            Assert.IsTrue(order.Installment.Price == 200 && order.Installment.Installments == 1 && order.Status == Core.Enums.EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        public void Return200WhenPaidParcelOrder()
        {
            var order = new Order(_customer);
            order.AddItem(new OrderItem(_product1, 3));
            order.Parcel(3);
            order.Pay(100);

            Assert.IsTrue(order.Installment.Price == 200 && order.Installment.Installments == 2 && order.Installment.InstallmentPrice == 100 && order.Status == Core.Enums.EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        public void ReturnSuccesWhenAddOrderItemInOrder()
        {
            var order = new Order(_customer);

            order.AddItem(new OrderItem(_product1, 3));

            Assert.IsTrue(order.Items.Any());
        }

        [TestMethod]
        public void Return0WhenPaidTotalOrderPrice()
        {
            var order = new Order(_customer);
            order.AddItem(new OrderItem(_product1, 2));

            order.Pay(200);

            Assert.IsTrue(order.Installment.Price == 0 && order.Installment.Installments == 0 && order.Installment.InstallmentPrice == 0 && order.Status == Core.Enums.EOrderStatus.Paid);
        }

        [TestMethod]
        public void ReturnTrueWhenCancelOrder()
        {
            var order = new Order(_customer);
            order.AddItem(new OrderItem(_product1, 2));

            order.Cancel();

            Assert.IsTrue(order.Status == Core.Enums.EOrderStatus.Canceled);
        }

        [TestMethod]
        public void ReturnFalseWhenAddInvalidOrderItemInOrder()
        {
            var order = new Order(_customer);

            order.AddItem(new OrderItem(_product3, 3));

            Assert.IsTrue(!order.Items.Any() && order.Invalid);
        }
    }
}
