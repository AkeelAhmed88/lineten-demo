using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;
using System.Data.Entity;

namespace LineTen.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LineTenContext _context;

        public CustomerRepository(LineTenContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);

            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteCustomerByIdAsync(int id)
        {
            var customerToDelete = await _context.FindAsync<Customer>(id);
            
            if (customerToDelete != null)
            {
                _context.Remove(customerToDelete);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
         
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.FindAsync<Customer>(id);

            return customer ?? new Customer();
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            var existingCustomerRecord = await _context.FindAsync<Customer>(id);

            if (existingCustomerRecord != null)
            {
                existingCustomerRecord.FirstName = customer.FirstName;
                existingCustomerRecord.LastName = customer.LastName;
                existingCustomerRecord.Phone = customer.Phone;
                existingCustomerRecord.Email = customer.Email;

                await _context.SaveChangesAsync();

                return existingCustomerRecord;
            }

            return new Customer();
        }
    }
}
