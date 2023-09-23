using LineTen.Api.Responses;
using LineTen.Domain.Entities;

namespace LineTen.Api.Extensions
{
    public static class CustomerExtensionscs
    {
        public static CustomerResponse? ToCustomerResponse(this Customer? result)
        {
            return result == null 
                ? null 
                : new CustomerResponse
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Phone = result.Phone,
                    Email = result.Email,
                };
        }

        public static IEnumerable<CustomerResponse> ToCustomerResponse(this IEnumerable<Customer> result)
        {
            return result.Select(c => new CustomerResponse
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Phone = c.Phone,
                Email = c.Email,
            });
        }
    }
}
