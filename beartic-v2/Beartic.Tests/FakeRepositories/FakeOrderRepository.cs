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

        public Task<Order> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
