using Beartic.Core.Entities;

namespace Beartic.Core.Interfaces
{
    public interface IOrderRepository
    {
        public Task AddAsync(Order order);
        public Task<Order> GetByIdAsync(string id);
        public void Update(Order order);
    }
}
