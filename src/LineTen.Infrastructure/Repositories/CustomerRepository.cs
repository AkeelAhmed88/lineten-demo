using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;

namespace LineTen.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LineTenContext _context;

        public CustomerRepository(LineTenContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Customer> CreateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }
         
        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
