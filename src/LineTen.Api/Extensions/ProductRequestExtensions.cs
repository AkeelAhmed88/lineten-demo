using LineTen.Api.Requests;
using LineTen.Domain.Entities;

namespace LineTen.Api.Extensions
{
    public static class ProductRequestExtensions
    {
        public static Product ToProduct(this ProductRequest request)
        {
            return new Product
            {
                Name = request.Name,
                Description = request.Description,
                Sku = request.Sku,
            };
        }
    }
}
