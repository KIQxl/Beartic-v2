using Beartic.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.EntitiesTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ReturnTrueGivenValidProduct()
        {
            var product = new Product("Produto 1", "Produto teste", 159.99m, 10);

            Assert.IsTrue(product.Valid);
        }

        [TestMethod]
        public void ReturnFalseGivenInvalidProduct()
        {
            var product = new Product("Produto 1", "Produto teste", 0, 10);

            Assert.IsTrue(product.Invalid);
        }

        [TestMethod]
        public void ReturnTrueWhenIncreaseProduct()
        {
            var product = new Product("Produto 1", "Produto teste", 0, 1);
            product.IncreaseQuantityProduct(9);
            Assert.IsTrue(product.QuantityOnHand == 10);
        }

        [TestMethod]
        public void ReturnTrueWhenDecreaseProduct()
        {
            var product = new Product("Produto 1", "Produto teste", 0, 10);
            product.DecreaseQuantityProduct(9);
            Assert.IsTrue(product.QuantityOnHand == 1);
        }
    }
}
