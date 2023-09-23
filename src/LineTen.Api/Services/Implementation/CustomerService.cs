using LineTen.Api.Extensions;
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

        public async Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request)
        {
            var result = await _repository.CreateCustomerAsync(request.ToCustomer());

            return result.ToCustomerResponse();
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            var result = await _repository.GetAllCustomersAsync();

            return result.ToCustomerResponse();
        }

        public async Task<CustomerResponse?> GetCustomerByIdAsync(int id)
        {
            var result = await _repository.GetCustomerByIdAsync(id);

            return result.ToCustomerResponse();
        }

        public async Task<CustomerResponse> UpdateCustomerByIdAsync(int id, CustomerRequest request)
        {
            var result = await _repository.UpdateCustomerAsync(id, request.ToCustomer());

            return result.ToCustomerResponse();
        }

        public async Task<bool> DeleteCustomerByIdAsync(int id)
        {
            return await _repository.DeleteCustomerByIdAsync(id);
        }
    }
}
