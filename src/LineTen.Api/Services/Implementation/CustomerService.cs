using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using LineTen.Domain.Repositories;

namespace LineTen.Api.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request)
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponse> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponse> UpdateCustomerByIdAsync(int id, CustomerRequest request)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICustomerService.DeleteCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
