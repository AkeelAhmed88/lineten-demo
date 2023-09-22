using LineTen.Api.Requests;
using LineTen.Domain.Entities;

namespace LineTen.Api.Extensions
{
    public static class CustomerRequestExtensions
    {
        public static Customer ToCustomer(this CustomerRequest request)
        {
            return new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
            };
        }
    }
}
