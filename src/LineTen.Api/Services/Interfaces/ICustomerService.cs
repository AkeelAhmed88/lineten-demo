using LineTen.Api.Requests;
using LineTen.Api.Responses;

namespace LineTen.Api.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request);

        Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();

        Task<CustomerResponse?> GetCustomerByIdAsync(int id);

        Task<CustomerResponse> UpdateCustomerByIdAsync(int id, CustomerRequest request);

        Task<bool> DeleteCustomerByIdAsync(int id);
    }
}
