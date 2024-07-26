using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Infraestructure.BussinessContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.BussinessContext.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BussinessData _ctx;

        public async Task AddAsync(Order order)
        {
            try
            {
                await _ctx.orders.AddAsync(order);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            try
            {
                return await _ctx.orders.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
