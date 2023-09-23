using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;

namespace LineTen.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly LineTenContext _context;

        public CustomerRepository(LineTenContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            return await CreateAsync(customer);
        }

        public async Task<bool> DeleteCustomerByIdAsync(int id)
        {
            return await DeleteByIdAsync<Customer>(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await GetAllEntitiesAsync<Customer>();
        }
         
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await GetByIdAsync<Customer>(id);
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
