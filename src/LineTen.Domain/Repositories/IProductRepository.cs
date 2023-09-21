using LineTen.Domain.Entities;

namespace LineTen.Domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task UpdateProductAsync(Product product);

        Task DeleteProductByIdAsync(int id);
    }
}
