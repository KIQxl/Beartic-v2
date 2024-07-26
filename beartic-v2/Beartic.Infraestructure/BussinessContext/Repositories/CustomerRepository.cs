using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Infraestructure.BussinessContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.BussinessContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BussinessData _ctx;

        public CustomerRepository(BussinessData ctx)
        {
            this._ctx = ctx;
        }

        public async Task AddAsync(Customer customer)
        {
            try
            {
                await _ctx.customers.AddAsync(customer);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public bool DocumentExists(string document)
        {
            try
            {
                return _ctx.customers.Any(x => x.Document.Number == document);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EmailExists(string email)
        {
            try
            {
                return _ctx.customers.Any(x => x.Email.Address == email);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Customer> GetByDocumentAsync(string document)
        {
            try
            {
                return await _ctx.customers.FirstOrDefaultAsync(x => x.Document.Number == document);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            try
            {
                return await _ctx.customers.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Remove(Customer customer)
        {
            try
            {
                _ctx.customers.Remove(customer);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                _ctx.customers.Entry(customer).State = EntityState.Modified;
                _ctx.customers.Update(customer);
            }
            catch (Exception ex)
            {
                return;
            };
        }
    }
}
