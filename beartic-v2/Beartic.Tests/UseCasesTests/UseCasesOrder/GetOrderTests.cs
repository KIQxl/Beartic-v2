using Beartic.Application.UseCases.OrderUseCases;
using Beartic.Core.Interfaces;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesOrder
{
    [TestClass]
    public class GetOrderTests
    {
        private readonly IOrderRepository _orderRepository = new FakeOrderRepository();
        private readonly ICustomerRepository _customerRepository = new FakeCustomerRepository();
        private readonly IProductRepository _productRepository = new FakeProductRepository();

        [TestMethod]
        public void GivenValidAndExistsOrderIdReturnResultStatus200()
        {
            var orderServices = new OrderServices(_orderRepository, _customerRepository, _productRepository);
            var order = orderServices.GetOrderByIdAsync("1");

            Assert.IsTrue(order.Result.Success && order.Result.Status == 200 && order.Result.Data.Price == 500m);
        }

        [TestMethod]
        public void GivenInvalidAndNotExistsOrderIdReturnResultStatus200()
        {
            var orderServices = new OrderServices(_orderRepository, _customerRepository, _productRepository);
            var order = orderServices.GetOrderByIdAsync("99");

            Assert.IsTrue(!order.Result.Success && order.Result.Status == 404);
        }
    }
}
