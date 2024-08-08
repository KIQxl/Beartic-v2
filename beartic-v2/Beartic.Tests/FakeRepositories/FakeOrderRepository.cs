using Beartic.Core.Entities;
using Beartic.Core.Interfaces;

namespace Beartic.Tests.FakeRepositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public Task AddAsync(Order order)
        {
            return Task.CompletedTask;
        }

        public Task CancelAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            if(id == "1")
            {
                var fakeCustomerRepository = new FakeCustomerRepository();
                var customer = await fakeCustomerRepository.GetByIdAsync("123");

                var fakeProductRepository = new FakeProductRepository();
                var product = await fakeProductRepository.GetProductByIdAsync("1");

                var order = new Order(customer);
                order.AddItem(new OrderItem(product, 5));

                return order;
            }

            return null;
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
