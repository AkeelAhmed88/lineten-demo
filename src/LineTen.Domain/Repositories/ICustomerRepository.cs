using LineTen.Domain.Entities;

namespace LineTen.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);
        
        Task<Customer> GetCustomerByIdAsync(int id);

        Task UpdateCustomerAsync(Customer customer);

        Task DeleteCustomerByIdAsync(int id);
    }
}
