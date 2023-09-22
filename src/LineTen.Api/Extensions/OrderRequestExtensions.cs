using LineTen.Api.Requests;
using LineTen.Domain.Entities;

namespace LineTen.Api.Extensions
{
    public static class OrderRequestExtensions
    {
        public static Order ToOrder(this OrderCreateRequest request)
        {
            return new Order
            {
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                Status = "Created",
                CreatedDate = DateTime.UtcNow
            };
        }

        public static Order ToOrder(this OrderUpdateRequest request)
        {
            return new Order
            {
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                Status = request.Status,
                UpdatedDate = DateTime.UtcNow
            };
        }
    }
}
