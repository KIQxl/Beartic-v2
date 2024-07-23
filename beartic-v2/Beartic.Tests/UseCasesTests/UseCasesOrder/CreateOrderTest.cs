using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.OrderItemUseCases.OrderItemDto;
using Beartic.Core.UseCases.OrderUseCases;
using Beartic.Core.UseCases.OrderUseCases.OrderDtos;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesOrder
{
    [TestClass]
    public class CreateOrderTest
    {
        private readonly IOrderRepository _orderRepository = new FakeOrderRepository();
        private readonly ICustomerRepository _customerRepository = new FakeCustomerRepository();
        private readonly IProductRepository _productRepository = new FakeProductRepository();

        [TestMethod]
        public void GivenValidRequestOrderPriceValueAndResultStatus201()
        {
            var orderService = new OrderServices(_orderRepository, _customerRepository, _productRepository);

            var listOrderItems = new List<CreateOrderItemDto>
            {
                new CreateOrderItemDto("1", 5),
                new CreateOrderItemDto("2", 1),
                new CreateOrderItemDto("3", 1),
                new CreateOrderItemDto("5", 1)
            };

            var createOrder = new CreateOrderDto("123", listOrderItems);
            var result = orderService.CreateOrder(createOrder);

            Assert.IsTrue(result.Result.Status == 201 && result.Result.Success && result.Result.Data?.Price == 1500);
        }
    }
}
