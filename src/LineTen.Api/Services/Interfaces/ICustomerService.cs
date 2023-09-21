using LineTen.Api.Requests;
using LineTen.Api.Responses;

namespace LineTen.Api.Services.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerRequest request);

        Task<CustomerResponse> GetCustomerById(int id);

        Task UpdateCustomerById(int id, CustomerRequest request);

        Task DeleteCustomerById(int id);
    }
}
