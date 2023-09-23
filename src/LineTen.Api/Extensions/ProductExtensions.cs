using LineTen.Api.Responses;
using LineTen.Domain.Entities;

namespace LineTen.Api.Extensions
{
    public static class ProductExtensions
    {
        public static ProductResponse? ToProductResponse(this Product? result)
        {
            return result == null 
                ? null 
                : new ProductResponse
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    Sku = result.Sku,
                };
        }

        public static IEnumerable<ProductResponse> ToProductResponse(this IEnumerable<Product> result)
        {
            return result.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Sku = p.Sku,
            });
        }
    }
}
