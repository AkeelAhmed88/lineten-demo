using LineTen.Api.Requests;
using LineTen.Api.Responses;

namespace LineTen.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> CreateProductAsync(ProductRequest request);

        Task<IEnumerable<ProductResponse>> GetAllProductsAsync();

        Task<ProductResponse?> GetProductByIdAsync(int id);

        Task<ProductResponse> UpdateProductByIdAsync(int id, ProductRequest request);

        Task<bool> DeleteProductByIdAsync(int id);
    }
}
