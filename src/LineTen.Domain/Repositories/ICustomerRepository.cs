using LineTen.Domain.Entities;

namespace LineTen.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        
        Task<Customer> GetCustomerByIdAsync(int id);

        Task UpdateCustomerAsync(Customer customer);

        Task DeleteCustomerByIdAsync(int id);
    }
}
