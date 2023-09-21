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

        public Task CreateCustomerAsync(CustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponse> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerById(int id, CustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
