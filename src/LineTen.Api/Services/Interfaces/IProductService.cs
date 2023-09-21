using LineTen.Api.Requests;
using LineTen.Api.Responses;

namespace LineTen.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateProductAsync(ProductRequest request);

        Task<IEnumerable<ProductResponse>> GetAllProductsAsync();

        Task<ProductResponse> GetProductById(int id);

        Task UpdateProductById(int id, ProductRequest request);

        Task DeleteProductById(int id);
    }
}
