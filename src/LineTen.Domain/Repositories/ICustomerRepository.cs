using LineTen.Domain.Entities;

namespace LineTen.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        
        Task<Customer> GetCustomerByIdAsync(int id);

        Task<Customer> UpdateCustomerAsync(int id, Customer customer);

        Task<bool> DeleteCustomerByIdAsync(int id);
    }
}
