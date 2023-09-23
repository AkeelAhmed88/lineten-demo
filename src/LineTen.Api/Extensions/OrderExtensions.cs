using LineTen.Api.Responses;
using LineTen.Domain.Entities;

namespace LineTen.Api.Extensions
{
    public static class OrderExtensions
    {
        public static OrderResponse? ToOrderResponse(this Order? result)
        {
            return result == null 
                ? null 
                : new OrderResponse
                {
                    Id = result.Id,
                    Product = new ProductResponse
                    {
                        Id = result.Product.Id,
                        Name = result.Product.Name,
                        Description = result.Product.Description,
                        Sku = result.Product.Sku,
                    },
                    Customer = new CustomerResponse
                    {
                        Id = result.Customer.Id,
                        FirstName = result.Customer.FirstName,
                        LastName = result.Customer.LastName,
                        Phone = result.Customer.Phone,
                        Email = result.Customer.Email,
                    },
                    Status = result.Status,
                    CreatedDate = result.CreatedDate,
                    UpdatedDate = result.UpdatedDate
                };
        }

        public static IEnumerable<OrderResponse> ToOrderResponse(this IEnumerable<Order> result)
        {
            return result.Select(o => new OrderResponse
            {
                Id = o.Id,
                Product = new ProductResponse
                {
                    Id = o.Product.Id,
                    Name = o.Product.Name,
                    Description = o.Product.Description,
                    Sku = o.Product.Sku,
                },
                Customer = new CustomerResponse
                {
                    Id = o.Customer.Id,
                    FirstName = o.Customer.FirstName,
                    LastName = o.Customer.LastName,
                    Phone = o.Customer.Phone,
                    Email = o.Customer.Email,
                },
                Status = o.Status,
                CreatedDate = o.CreatedDate,
                UpdatedDate = o.UpdatedDate
            });
        }
    }
}
