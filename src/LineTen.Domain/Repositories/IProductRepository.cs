using LineTen.Domain.Entities;

namespace LineTen.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<Product> UpdateProductAsync(Product product);

        Task<bool> DeleteProductByIdAsync(int id);
    }
}
