using Microsoft.EntityFrameworkCore;

using PCode.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCode.DataAccess.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(int id);
        IQueryable<Customer> GetAll();
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Delete(Customer customer);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PCodeContext _context;
        public CustomerRepository(PCodeContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return customer;
        }

        public async Task<Customer> Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return customer;
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public IQueryable<Customer> GetAll()
        {
            return _context.Customers.AsQueryable();
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return customer;
        }
    }
}
